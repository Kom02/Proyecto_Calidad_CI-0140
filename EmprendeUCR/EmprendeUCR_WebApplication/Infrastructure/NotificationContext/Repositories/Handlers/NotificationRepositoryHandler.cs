using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.Handlers
{
    public class NotificationRepositoryHandler : INotificationRepository
    {
        private readonly NotificationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        private IConfiguration _configuration;

        public INotificationRepository Next { set; get; }

        public NotificationRepositoryHandler(NotificationDbContext unitOfWork, IConfiguration configuration)
        {
            _dbContext = unitOfWork;
            _configuration = configuration;
            createChainResponsability();
        }

        private void createChainResponsability()
        {
            // Create instances to chain
            INotificationRepository clientNotifications = new ClientNotificationRepository(this._dbContext, this._configuration);
            INotificationRepository otherNotification = new EntrepeneurNotificationRepository(this._dbContext, this._configuration);
            // Set the chain responsability
            Next = clientNotifications;
            clientNotifications.Next = otherNotification;

        }

        public void EventsSubscriptions(UserNotification UserNotification)
        {
            if (Next is not null)
            {
                Next.EventsSubscriptions(UserNotification);
            }
        }

        public void GetNotifications(UserNotification UserNotification)
        {
            if (Next is not null)
            {
                Next.GetNotifications(UserNotification);
            }
        }

        public void GetNotificationsQuantity(UserNotification UserNotification)
        {
            if (Next is not null)
            {
                UserNotification.notificationQuantity = 0;
                Next.GetNotificationsQuantity(UserNotification);

            }
        }

        public void Unsubscription(UserNotification UserNotification)
        {
            if (Next is not null)
            {
                Next.Unsubscription(UserNotification);
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
