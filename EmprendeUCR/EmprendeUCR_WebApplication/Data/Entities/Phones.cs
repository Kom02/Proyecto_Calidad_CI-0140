using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Phones
    {
        [Key]
        public string User_Email { get; set; }
        [RegularExpression("[0-9].{7,7}")]
        public string Phone_Number { get; set; }
    }
}
