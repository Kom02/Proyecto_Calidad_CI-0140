using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Personalized_Status
    {
        [Key]
        [ForeignKey("Status")]
        public string Name { get; set; }
    }
}
