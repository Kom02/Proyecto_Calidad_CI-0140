using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class ServicePandemic
    {
        [Key]

        public int Code_ID { get; set; }
        public string Entrepreneur_Email { get; set; }
        public int Category_ID { get; set; }
        public string Service_Name { get; set; }
        public string Service_Description { get; set; }
        public int Price_per_hour { get; set; }
    }
}
