using System;
using System.Collections.Generic;

#nullable disable
/* This file is used to map the "Service" table and to used as a Service 
 * entity.
 */
namespace EmprendeUCR_WebApplication.Domain.Core.CoreEntities
{
    public partial class Service : ProductService
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int? PricePerHour { get; set; }
    }
}
