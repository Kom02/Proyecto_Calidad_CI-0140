using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities.Keyword
{
    public class Has_Keyword_Service
    {
        public int Service_ID { get; set; }
        public string Service_Entrepreneur_Email { get; set; }
        public int Service_Category_ID { get; set; }
        [Key]
        public int Keyword_ID { get; set; }
    }
}
