using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class SinpePaymentMethod
    {
        [Key]
        public int Phone_Number { get; set; }
        public string Entrepreneur_Email { get; set; }
    }
}