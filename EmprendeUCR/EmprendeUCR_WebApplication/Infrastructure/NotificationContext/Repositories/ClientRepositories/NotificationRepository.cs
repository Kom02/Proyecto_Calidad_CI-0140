using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Repositories;
using TableDependency.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Where;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;


/* This file is used to implement the methods used by queries to take, enter or
 * change data in the EmprendeUCR database, in the context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.ClientRepositories
{
    public class NotificationRepository : INotificationRepository
    {
        // A list to call the notifications that an specific user wants to listen
        List<Func<UserNotification,Task>> notificationsToReceive = new List<Func<UserNotification,Task>>();
        List<Func<UserNotification, int>> notifications = new List<Func<UserNotification, int>>();
        List<Action<UserNotification>> notificationToSuscribe = new List<Action<UserNotification>>();
        private readonly NotificationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public INotificationRepository Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private List<SqlTableDependency<Notification>> _NotifierOrderNotificationClient;
        public event newEventNotification onEventNotification;
        private IConfiguration _configuration;

        /* Summary: Take the data base, in the context of the orders, and 
         *          assigns it to the _dbContext varible to use it in the 
         *          future.
         * Parameters: Receives the data base, in the context of the orders.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public NotificationRepository(NotificationDbContext unitOfWork, IConfiguration configuration)
        {
            _dbContext = unitOfWork;
            _configuration = configuration;
            notificationsToReceive.Add(EntrepeneurOrdersAccepted);      // 1
            notificationsToReceive.Add(ClientsOrdersAcceptedRejected);  // 0
            

        }

        /* Summary: Retrieves all the notifications, of a specific user
         * Parameters: Receives the user's email and the type of notification wanted.
         * Return: A list of notifications.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<UserNotification> GetByIdAsync(string email, int type) {
            var user = new UserNotification(email, type);
            var callMethods = user.getNotificationsWanted();
            // Using the iterator, it is possible to fill the notifications that a particular user is interested to fill and to listen
            foreach (var iterable in callMethods) {
                await notificationsToReceive[iterable].Invoke(user);
            }
            return user;
        }


        /* Summary: Update a specific userNotification.
         * Note: UserNotification is a derivate for a User use in this context
         * Therefore it is used as the aggregate on this context
         * Parameters: Receives the userNotification.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public async Task notificationsUpdate(UserNotification userUpdate) {
            _dbContext.Update(userUpdate);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task ClientsOrdersAcceptedRejected(UserNotification user)
        {
            /*List<Notification> list =
                    _dbContext.OrderNotificationEntrepeneurs.
                        Where(e => e.ClientEmail == user.Email && (e.State == "Pendiente"))
                        .ToList<Notification>();
            var lists = (list);
            user.setNewNotifications(list);*/

            Expression<Func<OrderNotificationEntrepeneur, bool>> expression = e =>
                  e.EntrepreneurEmail == user.Email && (e.State == "Pendiente");
            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationEntrepeneur>(
            expression);
            SqlTableDependency<Notification> sqlTableDependency = new SqlTableDependency<Notification>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition);
            //sqlTableDependency.OnChanged += this.TableDependency_Changed;
            sqlTableDependency.Start();
            _NotifierOrderNotificationClient.Add(sqlTableDependency);
        }

        public async Task EntrepeneurOrdersAccepted(UserNotification user)
        {
            List<Notification> list = 
                    _dbContext.OrderNotificationEntrepeneurs.
                        Where(e => e.ClientEmail == user.Email  && (e.State == "Rechazado" || e.State == "Aceptado" ))
                        .ToList<Notification>();
            var lists = (list);
            user.setNewNotifications(list);
            var mapper = new ModelToTableMapper<OrderNotificationEntrepeneur>();
            mapper.AddMapping(e => e.ClientEmail, "Client_Email");
            Expression<Func<OrderNotificationEntrepeneur, bool>> expression = e =>
                  e.State == "Pendiente" && e.ClientEmail == "Herson@ucr.ac.cr";

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationEntrepeneur>(
            expression,
            mapper);
            
            SqlTableDependency<OrderNotificationEntrepeneur> sqlTableDependency = new SqlTableDependency<OrderNotificationEntrepeneur>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition,mapper:mapper);
            
            sqlTableDependency.OnChanged += this.TableDependency_Changed;
            
            sqlTableDependency.Start();
            
            //_NotifierOrderNotificationClient.Add(sqlTableDependency);
        }

        public void TableDependency_Changed(object sender, RecordChangedEventArgs<OrderNotificationEntrepeneur> e)
        {
            var changedEntity = e.Entity;//No consigue el nombre por que no es parte de la tabla!!! VITAL!!
            //this.OnNotificationChangeds.Invoke(this);
        }

        public async Task<int> getNotificationQuantity(UserNotification user)
        {
            //var user = new UserNotification(email, type); // Create user in presentation
            int quantity = 0;
            var callMethods = user.getNotificationsWanted();
            // Using the iterator, it is possible to get the number of notification for a particular user is interested to listen
            foreach (var iterable in callMethods)
            {
                quantity =+ notifications[iterable].Invoke(user);
                notificationToSuscribe[iterable].Invoke(user);
            }
            return quantity;
        }
        public int EntrepeneursOrderQuantity(UserNotification user)
        {
            int quantity = _dbContext.OrderNotificationEntrepeneurs.
                        Where(e => e.EntrepreneurEmail == user.Email && (e.State == "Pendiente" || e.State == "Aceptado"))
                        .Count();
            return quantity;
        }

        public void OrderNotificationSuscription(UserNotification user) {
            var mapper = new ModelToTableMapper<OrderNotificationEntrepeneur>();

            mapper.AddMapping(e => e.ClientEmail, "Client_Email");

            Expression<Func<OrderNotificationEntrepeneur, bool>> expression = e =>
                  e.State == "Pendiente" && e.ClientEmail == "Herson@ucr.ac.cr";

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationEntrepeneur>(
            expression,
            mapper);

            SqlTableDependency<OrderNotificationEntrepeneur> sqlTableDependency = new SqlTableDependency<OrderNotificationEntrepeneur>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition, mapper: mapper);
            //sqlTableDependency.OnChanged += this.OrderEntrepeneurChange;
            sqlTableDependency.Start();
        }

        public int GetQuantity(string email, int type)
        {

            /* TO ENTREPENEUR MOVEMENT
            var mapper = new ModelToTableMapper<OrderNotificationEntrepeneur>();

            mapper.AddMapping(e => e.EntrepreneurEmail, "Entrepreneur_Email");

            Expression<Func<OrderNotificationEntrepeneur, bool>> expression = e =>
                  (e.State == "Pendiente de revision" || e.State == "Aceptado" || e.State == "Rechazado")  && e.EntrepreneurEmail == "saguilar1999@hotmail.com";

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationEntrepeneur>(
            expression,
            mapper);

            SqlTableDependency<OrderNotificationEntrepeneur> sqlTableDependency = new SqlTableDependency<OrderNotificationEntrepeneur>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition, mapper: mapper);
            sqlTableDependency.OnChanged += this.OrderEntrepeneurChange;
            sqlTableDependency.Start();

            

            return _dbContext.OrderNotificationClients.
                        Where(e => e.EntrepeneurEmail == email && (e.State == "Pendiente de revision"))
                        .Count();

            

            */


            // Client movement

            var mapper = new ModelToTableMapper<OrderNotificationClient>();

            mapper.AddMapping(e => e.ClientEmail, "Client_Email");

            Expression<Func<OrderNotificationClient, bool>> expression = e =>
                  ( e.State == "Aceptado" || e.State == "Rechazado") && e.ClientEmail == email; //"soru1097@gmail.com"

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationClient>(
            expression,
            mapper);

            SqlTableDependency<OrderNotificationClient> sqlTableDependency = new SqlTableDependency<OrderNotificationClient>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition, mapper: mapper);
            sqlTableDependency.OnChanged += this.OrderClientChange;
            sqlTableDependency.Start();


            return  _dbContext.OrderNotificationEntrepeneurs.
                        Where(e => e.ClientEmail == email && (e.State == "Rechazado" || e.State == "Aceptado"))
                        .Count();
        }

        private void OrderEntrepeneurChange(object sender, RecordChangedEventArgs<OrderNotificationEntrepeneur> e)
        {
            var changedEntity = e.Entity;
            if (changedEntity.EntrepreneurEmail == "saguilar1999@hotmail.com" && changedEntity.State == "Pendiente de revision")
            {
                onEventNotification.Invoke(this, new NotificationChangeEventArgs(true));
            }
            else {
                onEventNotification.Invoke(this, new NotificationChangeEventArgs(false));
            }

        }

        private void OrderClientChange(object sender, RecordChangedEventArgs<OrderNotificationClient> e)
        {
            var changedEntity = e.Entity;
            if (changedEntity.ClientEmail == "soru1097@gmail.com" && (changedEntity.State == "Aceptado" || changedEntity.State == "Rechazado"))
            {
                if (changedEntity.view) {
                    onEventNotification.Invoke(this, new NotificationChangeEventArgs(false));
                }
                else
                {
                    onEventNotification.Invoke(this, new NotificationChangeEventArgs(true));
                }
            }
        }

        public UserNotification GetUserNotification(string email, int type)
        {
            var user = new UserNotification(email, type);
            user.notificationQuantity = this.GetQuantity(email,type);
            if (this.onEventNotification is not null)
            {
                this.onEventNotification -= user.QuantityEvent;
                this.onEventNotification += user.QuantityEvent;
            }
            else {
                this.onEventNotification += user.QuantityEvent;
            }
            
            return user;
        }

        public void EventsSubscriptions(UserNotification UserNotification)
        {
            throw new NotImplementedException();
        }

        public void GetNotifications(UserNotification UserNotification)
        {
            throw new NotImplementedException();
        }

        public void GetNotificationsQuantity(UserNotification UserNotification)
        {
            throw new NotImplementedException();
        }

        public void Unsubscription(UserNotification UserNotification)
        {
            throw new NotImplementedException();
        }

        public int GetProductsQuantity(UserNotification UserNotification)
        {
            throw new NotImplementedException();
        }

        /* public void OrderEntrepeneurChange(object sender, RecordChangedEventArg
         * 
         * s<OrderNotificationEntrepeneur> e)
         {
             var changedEntity = e.Entity;
             if (changedEntity.AreYouGoingToDecrement()) {
                 //this.OnNotificationChangeds.Invoke(this);
             }
             if (changedEntity.AreYouGoingToIncrement())
             {
                 //this.OnNotificationChangeds.Invoke(this);
             }


         }*/

    }
}
