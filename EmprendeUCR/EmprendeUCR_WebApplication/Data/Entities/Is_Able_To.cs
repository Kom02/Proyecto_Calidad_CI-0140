using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Is_Able_To
    {
        [Key]
        public string Email { get; set; }
        public int Role_Id { get; set; }
        public int Permission_Id { get; set; }
    }
}
