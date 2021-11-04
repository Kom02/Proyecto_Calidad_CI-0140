using EmprendeUCR_WebApplication.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Domain.NotificationContext
{

    public delegate Task newEventNotification(object sender, NotificationChangeEventArgs notification);
    public class NotificationChangeEventArgs : EventArgs
    {
        public bool Increment { get; }

        public NotificationChangeEventArgs(bool increment)
        {
            this.Increment = increment;
        }
    }
    public class UserNotification : AggregateRoot
    {
        public enum notificationsToReceive
        {
            ClientsOrdersAcceptedRejected,  // 0
            EntrepeneurOrdersAccepted      // 1
            
        }

        public string Email { set; get; }
        public int TypeUser { set; get; }
        public List<Notification> Notifications { set; get; }
        public bool alreadySubscribed { set; get; }

        public void orderNotifications()
        {
            if (this.Notifications is not null) {
                Notifications = Notifications.OrderByDescending(x => x.date).ToList();
            }
        }

        public int notificationQuantity { set; get; }

       
        public event newEventNotification OnNotificationChangeds;
        public UserNotification(string email, int typeUser) {
            Email = email;
            TypeUser = typeUser;
            switch (typeUser){
                case 0: //Entrepeneur

                    break;
            }
            Notifications = new List<Notification>();
           
        }

        public async Task QuantityEvent(object sender, NotificationChangeEventArgs e)
        {
            if (e.Increment)
            {
                notificationQuantity++;
            }
            else {
                notificationQuantity--;
            }
            if (OnNotificationChangeds is not null) {
                await OnNotificationChangeds.Invoke(sender, e);
            }
            //notificationQuantity = e.Increment ? notificationQuantity++ : notificationQuantity--;
        }


        public List<int> getNotificationsWanted() {
            List<int> listNotifications = new List<int>();
            switch (TypeUser) {
                case 1: // Client
                    listNotifications.Add((int)notificationsToReceive.ClientsOrdersAcceptedRejected);
                    break;
                case 2: // Entrepeneur
                    listNotifications.Add((int)notificationsToReceive.EntrepeneurOrdersAccepted);
                    break;
                case 3: // Admin
                    break;
            }             
            return listNotifications;
        }
        public void setNewNotifications(List<Notification> newNotifications) {
            Notifications.AddRange(newNotifications);
        }
        public void notificationPoll() { 
            
        }

       
    }
}
