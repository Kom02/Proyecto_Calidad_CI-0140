using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to map the "Generic_Status" table and to used as a
 * GenericStatus entity that inherits from the Status entity.
 */
namespace EmprendeUCR_WebApplication.Domain.OrderContext.Entities
{
    public partial class GenericStatus
    {
        public string Name { get; set; }

        // Foreign entities
        private readonly List<Order> _orderList;
        public IReadOnlyCollection<Order> Order;
        public Status status { get; set; }
    }
}
