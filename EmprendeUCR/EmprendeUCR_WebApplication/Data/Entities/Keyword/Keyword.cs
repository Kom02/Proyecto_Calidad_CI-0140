using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities.Keyword
{
    public class Keywords
    {
        [Key]
        public int Id { get; set; }
        /**
        * @brief setter and getter of the Title of the category
        */
        public string Title { get; set; }
    }
}
