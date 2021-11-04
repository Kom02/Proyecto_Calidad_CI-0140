using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Alliance
    {

        [Key]
        public Int32 Alliance_Id { get; set; }
        public string User_Email { get; set; }

        public string Ally_User_Email { get; set; }


        public int  Alliance_Status { get; set; }
    }
}
