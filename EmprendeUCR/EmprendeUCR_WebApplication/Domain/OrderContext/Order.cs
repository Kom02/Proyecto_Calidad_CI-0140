using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Domain.OrderContext
{
    public class Order
    {
        public DateTime DateAndHourCreation;
        public string Details;
        public DateTime DeliveryDate;
        public int CodeID;
        public String EntrepreneurEmail;
        public int CategoryID;
    }
}
