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

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.EntrepeneurRepositories
{
    public class OrderNotificationEntrepeneurRepository : INotificationRepository
    {
        private readonly NotificationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        private IConfiguration _configuration;
        public INotificationRepository Next { set; get; }

        private string EmailToListen { set; get; }
        public event newEventNotification onEventNotification;
        SqlTableDependency<OrderNotificationEntrepeneur> sqlTableDependency;
        public OrderNotificationEntrepeneurRepository(NotificationDbContext unitOfWork, IConfiguration configuration)
        {
            _dbContext = unitOfWork;
            _configuration = configuration;
        }
        public void EventsSubscriptions(UserNotification UserNotification)
        {
            // Subscription is created
            // Email that wants to be listen
            this.EmailToListen = UserNotification.Email;
            var mapper = new ModelToTableMapper<OrderNotificationEntrepeneur>();
            mapper.AddMapping(e => e.EntrepreneurEmail, "Entrepreneur_Email");
            // Where clause 
            Expression<Func<OrderNotificationEntrepeneur, bool>> expression = e =>
                  (e.State == "Pendiente de revision" || e.State == "Aceptado" || e.State == "Rechazado") && e.EntrepreneurEmail ==(string)this.EmailToListen;

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<OrderNotificationEntrepeneur>(
            expression,
            mapper);
            // Create dependency in Order table with previous where clause
            sqlTableDependency = new SqlTableDependency<OrderNotificationEntrepeneur>(_configuration.GetConnectionString("DefaultConnection"), "Order", filter: whereCondition, mapper: mapper);
            sqlTableDependency.OnChanged += this.OrderEntrepeneurChange;
            

            if (Next is not null) {
                Next.EventsSubscriptions(UserNotification);
            }
            // User subscribed
            this.onEventNotification += UserNotification.QuantityEvent;
            // Begin to listen changes
            sqlTableDependency.Start();
        }
        /*
          Summary: check all notifications for the entrepreneur logged and saves it in UserNotifications. 
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void GetNotifications(UserNotification UserNotification)
        {
            List<Notification> list =
                    _dbContext.OrderNotificationEntrepeneurs.
                        Where(e => e.EntrepreneurEmail == UserNotification.Email && (e.State == "Pendiente de revision"))
                        .ToList<Notification>();
            UserNotification.setNewNotifications(list);
            if (Next is not null)
            {
                Next.GetNotifications(UserNotification);
            }
        }
        /*
          Summary: check the count of all notifications for the entrepreneur logged and saves it in UserNotifications. 
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void GetNotificationsQuantity(UserNotification UserNotification)
        {
            UserNotification.notificationQuantity = UserNotification.notificationQuantity + _dbContext.OrderNotificationEntrepeneurs.
                        Where(e => e.EntrepreneurEmail == UserNotification.Email && (e.State == "Pendiente de revision"))
                        .Count();
            if (Next is not null)
            {
                Next.EventsSubscriptions(UserNotification);
            }
            
        }
        /*
          Summary: check the count of all notifications for the client logged and saves it in UserNotifications. 
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        private void OrderEntrepeneurChange(object sender, RecordChangedEventArgs<OrderNotificationEntrepeneur> e)
        {
            var changedEntity = e.Entity;
            if (changedEntity.EntrepreneurEmail == (string)EmailToListen && changedEntity.State == "Pendiente de revision")
            {
                onEventNotification.Invoke(this, new NotificationChangeEventArgs(true));
            }
            else
            {
                onEventNotification.Invoke(this, new NotificationChangeEventArgs(false));
            }

        }

        public void Unsubscription(UserNotification UserNotification)
        {
            this.onEventNotification -= UserNotification.QuantityEvent;
            // Begin to listen changes
            if (sqlTableDependency is not null)
            {
                sqlTableDependency.Stop();
            }
        }

        public int GetProductsQuantity(UserNotification UserNotification)
        {
            int quantity = 0;
            if (Next is not null)
            {
                quantity =  Next.GetProductsQuantity(UserNotification);
            }
            return quantity;
        }
    }
}
