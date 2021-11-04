using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Card
    {

        [Key]
        /**
        * @brief setter and getter of the Name of the Card
        */
        public string Name { get; set; }

        /**
        * @brief setter and getter of the status of a Card
        */
        public bool Status { get; set; }

        /**
        * @brief setter and getter of the Brand of a Card
        */
        public string Brand  { get; set; }
    }

}
