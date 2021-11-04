using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Where;

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.ClientRepositories
{
    public class OrderNotificationClientRepository : INotificationRepository
    {
        private readonly NotificationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        private IConfiguration _configuration;
        public INotificationRepository Next { set; get; }
        private string EmailToListen { set; get; }
        public event newEventNotification onEventNotification;
        SqlTableDependency<OrderNotificationClient> sqlTableDependency;

        public OrderNotificationClientRepository()
        {
        }

        public OrderNotificationClientRepository(NotificationDbContext unitOfWork, IConfiguration configuration)
        {
            _dbContext = unitOfWork;
            _configuration = configuration;
        }

        public void EventsSubscriptions(UserNotification UserNotification)
        {
            // Subscription is created
            // Email that wants to be listen
            this.EmailToListen = UserNotification.Email;

            var mapper = new ModelToTableMapper<OrderNotificationClient>();

            mapper.AddMapping(e => e.ClientEmail, "Client_Email");
            // Where clause
            Expression<Func<OrderNotificationClient, bool>> expression = e =>
                  (e.State == "Aceptado" || e.State == "Rechazado") && e.ClientEmail == (string)EmailToListen; //"soru1097@gmail.com"

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationClient>(
            expression,
            mapper);

            // Create dependency in Order table with previous where clause
            if (_configuration is not null) {
                sqlTableDependency = new SqlTableDependency<OrderNotificationClient>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition, mapper: mapper);
                sqlTableDependency.OnChanged += this.OrderClientChange;
            }

            if (Next is not null) {
                Next.EventsSubscriptions(UserNotification);
            }

            // User subscribed
            this.onEventNotification += UserNotification.QuantityEvent;

            // Begin to listen changes
            if (_configuration is not null)
            {
                sqlTableDependency.Start();
            }
        }

        /*
          Summary: check all notifications for the client logged and saves it in UserNotifications. 
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void GetNotifications(UserNotification UserNotification)
        {
            List<Notification> list =
                   _dbContext.OrderNotificationClients.
                       Where(e => e.ClientEmail == UserNotification.Email && (e.State == "Rechazado" || e.State == "Aceptado") )
                       .ToList<Notification>();
            UserNotification.setNewNotifications(list);
            if (Next is not null)
            {
                Next.GetNotifications(UserNotification);
            }
        }
        /*
          Summary: check the count of all notifications for the client logged and saves it in UserNotifications. 
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void GetNotificationsQuantity(UserNotification UserNotification)
        {
            UserNotification.notificationQuantity += _dbContext.OrderNotificationClients.
                       Where(e => e.ClientEmail == UserNotification.Email && (e.State == "Rechazado" || e.State == "Aceptado"))
                       .Count();
        }
        /*
          Summary: check the count of all notifications for the client logged and saves it in UserNotifications. 
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void OrderClientChange(object sender, RecordChangedEventArgs<OrderNotificationClient> e)
        {
            var changedEntity = e.Entity;
            if (changedEntity.ClientEmail == (string)EmailToListen && (changedEntity.State == "Aceptado" || changedEntity.State == "Rechazado"))
            {
                if (changedEntity.view)
                {
                    InvokeEvent(false);
                }
                else
                {
                    InvokeEvent(true);
                }
            }
        }
        /*
          Summary: unsubscribe UserNotifications to not hear more updates from the database.
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void Unsubscription(UserNotification UserNotification)
        {
            this.onEventNotification -= UserNotification.QuantityEvent;
            // Begin to listen changes
            if (sqlTableDependency is not null) {
                sqlTableDependency.Stop();
            }          
        }

        public void InvokeEvent(bool result)
        {
            if (onEventNotification is not null)
            {
                onEventNotification.Invoke(this, new NotificationChangeEventArgs(result));
            }
        }

        public int GetProductsQuantity(UserNotification UserNotification)
        {
            int quantity = 0;
            if (Next is not null)
            {
                quantity = Next.GetProductsQuantity(UserNotification);
            }
            return quantity;
        }
    }
}
