using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Is_Offer
    {
        [Key]
        public int Offer_ID { get; set; }
        public int Code_ID { get; set; }

        public string User_Email { get; set; }
        public int Category_ID { get; set; }
        public int Amount { get; set; }
    }
}
