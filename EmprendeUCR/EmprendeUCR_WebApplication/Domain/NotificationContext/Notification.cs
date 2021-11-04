using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using System;

/*
    Notification: An abstract class. It is meant to be inherited from by other
    notification-like class types.
*/
namespace EmprendeUCR_WebApplication.Domain.NotificationContext
{
    public partial class Notification
    {    
        public DateTime date { get; set; }

        public string url { get; set; }

        public virtual string color { get; set; }
        public byte Type { get; set; }

    /*
        Summary: This is a virtual method, meant to be overriden by other 
                 classes to return a different string.
        Parameters: None.
        Return: A string, set to a default message.
        Exceptions: None.
    */
        public virtual string ToString()
        {
            return "Ha recibido una nueva notificación";
        }

    }
}
