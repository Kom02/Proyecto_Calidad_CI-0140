using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
  OrderNotificationClient: A type of notification, which inherits from abstract
  class Notification. It contains methods and atributes needed to contain and
  retrieve a recently submitted order's entrepreneur name and status for 
  clients, which are the pieces of information meant to be displayed in a 
  notification for clients.
*/
namespace EmprendeUCR_WebApplication.Domain.NotificationContext
{
    public class OrderNotificationClient  : Notification
    {
        public string ClientEmail { get; set; }
        public DateTime DateAndHourCreation { get; set; }
        public string State { set; get; }
        public string NameEntrepenur { set; get; }
        public bool view { get; set; }
        /*
          Summary: A simple, one-line method that returns a string with 
                   different values and color.
          Parameters: None
          Return: A string.
          Exceptions: None.
        */
        public override string color { get { return State == "Rechazado" ? "danger" : "success"; } }
        public OrderNotificationClient()
        {
            url = "/ClientRequest";
        }

        /*
          Summary: Overriden method from Notification abstract class. It simply
                   returns a string indicating the order's entrepreneur name and
                   the order's current status.
          Parameters: None
          Return: A string, indicating the status and entrepreneur in charge
          Exceptions: None
        */
        public override string ToString()
        {
            return "Su pedido a " + NameEntrepenur + " fue " + State;
        }
    }
}
