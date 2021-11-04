using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to map the "Has_Status" table and to used as a
 * ProductHasStatus entity.
 */
namespace EmprendeUCR_WebApplication.Domain.OrderContext.Entities
{
    public partial class ProductHasStatus
    {
        public string Name { get; set; }
        public int CodeId { get; set; }
        public string EntrepreneurEmail { get; set; }
        public int CategoryId { get; set; }
        public int Order { get; set; }

        // Foreign entities
        public ProductService productService { get; set; }
        public PersonalizedStatus personalizedStatus { get; set; }
    }
}
