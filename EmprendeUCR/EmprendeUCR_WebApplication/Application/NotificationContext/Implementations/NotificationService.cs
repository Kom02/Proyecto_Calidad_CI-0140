using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Repositories;

namespace EmprendeUCR_WebApplication.Application.NotificationContext.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        /*
          Summary: UserNotification is subscribed to listen to the notification table.
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        /*
          Summary: UserNotification is subscribed to listen to the notification table.
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void EventsSubscriptions(UserNotification UserNotification)
        {
            _notificationRepository.EventsSubscriptions(UserNotification);
        }
        /*
          Summary: update all the notifications linked to the UserNotification within the same User Notification
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void GetNotifications(UserNotification UserNotification)
        {
            _notificationRepository.GetNotifications(UserNotification);
            UserNotification.orderNotifications();
        }
        /*
          Summary: update the notification counter in UserNotification
          Parameters: UserNotification
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public void GetNotificationsQuantity(UserNotification UserNotification)
        {
            _notificationRepository.GetNotificationsQuantity(UserNotification);
        }

        public int GetProductsQuantity(UserNotification UserNotification)
        {
            return _notificationRepository.GetProductsQuantity(UserNotification);
        }

        /*
         Summary: UserNotification is unsubscribed to not listen to the notification table.
         Parameters: UserNotification
         Return: Nothing
         Exceptions: There aren't known exceptions
        */
        public void Unsubscription(UserNotification UserNotification)
        {
            _notificationRepository.Unsubscription(UserNotification);
        }

        /*public async Task<List<Notification>> GetNotifications(string email, int type)
        {
            var list = new List<Notification>();
            list.Add(new Notification { date = new DateTime(2022, 3, 1, 7, 0, 0), color="danger", url= "/ClientRequest",  Message = "Su pedido a Silvia Aguilar fue rechazado ", Type = 2 });
            list.Add(new Notification { date = new DateTime(2048, 3, 1, 7, 0, 0),  color = "success", url = "/ClientRequest", Message = "Su pedido a Herson Mora fue aceptado  ", Type = 2 });
            list.Add(new Notification { date = new DateTime(2001, 6, 1, 7, 0, 0),  color = "warning", url = "/OrderAcceptance",  Message = "Tiene un nuevo Pedido", Type = 2 });

            list.OrderByDescending(o => o.Message).ToList();
            list.Sort((p, q) => p.date.CompareTo(q.date));
            return list;
        }*/


    }
}
