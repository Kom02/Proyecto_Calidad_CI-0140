using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

namespace EmprendeUCR_WebApplication.Application.NotificationContext
{
    interface INotificationService
    {
        /*
          Summary: UserNotification is subscribed to listen to the notification table.
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        void EventsSubscriptions(UserNotification UserNotification);
        /*
          Summary: update all the notifications linked to the UserNotification within the same User Notification
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        void GetNotifications(UserNotification UserNotification);
        /*
          Summary: update the notification counter in UserNotification
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        void GetNotificationsQuantity(UserNotification UserNotification);
        /*
          Summary: UserNotification is unsubscribed to not listen to the notification table.
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        void Unsubscription(UserNotification UserNotification);

        int GetProductsQuantity(UserNotification UserNotification);
    }
}
