using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used as a interface of the file NotificationRepository.
 */
namespace EmprendeUCR_WebApplication.Domain.Repositories
{
    enum Users
    {
        NotUser,
        Client,
        Entrepeneur,
        Admin
    }
    public interface INotificationRepository : IRepository<UserNotification>
    {
        INotificationRepository Next { set; get; }
        void EventsSubscriptions(UserNotification UserNotification);
        virtual void GetNotifications(UserNotification UserNotification) { }
        virtual void GetNotificationsQuantity(UserNotification UserNotification) { }
        void Unsubscription(UserNotification UserNotification);
        int GetProductsQuantity(UserNotification UserNotification);


        /*Task<UserNotification> GetByIdAsync(string email, int type);
        Task notificationsUpdate(UserNotification userUpdate);
        Task ClientsOrdersAcceptedRejected(UserNotification user);
        Task EntrepeneurOrdersAccepted(UserNotification user);
        int GetQuantity(string email, int type);
        UserNotification GetUserNotification(string email, int type);
        */
    }
}
