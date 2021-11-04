using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Repositories;
using EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.EntrepeneurRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.Handlers
{
    public class EntrepeneurNotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        private IConfiguration _configuration;

        public INotificationRepository Next { set; get; }
        public INotificationRepository Child { set; get; }

        public EntrepeneurNotificationRepository(NotificationDbContext unitOfWork, IConfiguration configuration)
        {
            _dbContext = unitOfWork;
            _configuration = configuration;
            createChainResponsability();
        }

        private void createChainResponsability()
        {
            // Create instances to chain
            INotificationRepository OrderNotification = new OrderNotificationEntrepeneurRepository(this._dbContext, this._configuration);
            // Set the chain responsability
            Child = OrderNotification;

        }

        public void EventsSubscriptions(UserNotification UserNotification)
        {
            if (UserNotification.TypeUser == (int)Users.Entrepeneur)
            {
                if (Child is not null) {
                    Child.EventsSubscriptions(UserNotification);
                }
            }
            else
            {
                if (Next is not null)
                {
                    Next.EventsSubscriptions(UserNotification);
                }
            }
        }

        public void GetNotifications(UserNotification UserNotification)
        {
            if (UserNotification.TypeUser == (int)Users.Entrepeneur)
            {
                if (Child is not null)
                {
                    Child.GetNotifications(UserNotification);
                }                
            }
            else
            {
                if (Next is not null)
                {
                    Next.GetNotifications(UserNotification);
                }
            }
        }

        public void GetNotificationsQuantity(UserNotification UserNotification)
        {
            if (UserNotification.TypeUser == (int)Users.Entrepeneur)
            {
                if (Child is not null)
                {
                    Child.GetNotificationsQuantity(UserNotification);
                }
            }
            else
            {
                if (Next is not null)
                {
                    Next.GetNotificationsQuantity(UserNotification);
                }
            }
        }

        public void Unsubscription(UserNotification UserNotification)
        {
            if (UserNotification.TypeUser == (int)Users.Entrepeneur)
            {
                if (Child is not null)
                {
                    Child.Unsubscription(UserNotification);
                }
            }
            else
            {
                if (Next is not null)
                {
                    Next.Unsubscription(UserNotification);
                }
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
