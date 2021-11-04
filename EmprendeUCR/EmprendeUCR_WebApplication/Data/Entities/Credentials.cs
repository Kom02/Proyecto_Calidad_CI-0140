using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Credentials
    {
        [Key]
        public string User_Email { get; set; }
        public string Password { get; set; }
    }
}
