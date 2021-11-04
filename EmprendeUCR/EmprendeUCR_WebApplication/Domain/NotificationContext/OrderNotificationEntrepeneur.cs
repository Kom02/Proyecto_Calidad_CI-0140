using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
  OrderNotificationEntrepreneur: A type of notification, which inherits from 
  abstract class Notification. It contains methods and atributes needed to 
  contain and retrieve a recently submitted order's client in a notification 
  for entrepreneurs.
*/

namespace EmprendeUCR_WebApplication.Domain.NotificationContext
{
    public class OrderNotificationEntrepeneur : Notification
    {
        public string ClientEmail { get; set; }
        public DateTime DateAndHourCreation { get; set; }
        
        public string State { set; get; }
        public string EntrepreneurEmail { get; set; }
        public string nameClient { set; get; }
        public OrderNotificationEntrepeneur() {
            url = "/OrderAcceptance";
            color = "warning"; 
        }
     /*
       Summary: Overriden method from Notification abstract class. It simply
                returns a string indicating the order's client.
       Parameters: None
       Return: A string, indicating the status and entrepreneur in charge
       Exceptions: None
     */
        public override string ToString()
        {
            return "Tiene un nuevo pedido de " + nameClient ;
        }

    }
}
