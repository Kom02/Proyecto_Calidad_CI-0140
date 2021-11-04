using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to map the "Status" table and to used as a Status entity.
 */
namespace EmprendeUCR_WebApplication.Domain.OrderContext.Entities
{
    public class Status
    {
        public string Name { get; set; }
        public string PreviousStateName { get; set; }

        // Foreign entities
        public Status previousStatus { get; set; }
        public Status posteriorStatus { get; set; }
        public PersonalizedStatus personalizedStatus { get; set; }
        public GenericStatus genericStatus { get; set; }

        private readonly List<Organized> _organizedList;
        public IReadOnlyCollection<Organized> Organized;
    }
}
