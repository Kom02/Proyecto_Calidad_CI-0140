using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to map the "Personalized_Status" table and to used as a
 * PersonalizedStatus entity that inherits from the Status entity.
 */
namespace EmprendeUCR_WebApplication.Domain.OrderContext.Entities
{
    public partial class PersonalizedStatus
    {
        public string Name { get; set; }

        // Foreign entities
        private readonly List<ProductHasStatus> _productHasStatusList;
        public IReadOnlyCollection<ProductHasStatus> ProductHasStatus;
        public Status status { get; set; }
    }
}
