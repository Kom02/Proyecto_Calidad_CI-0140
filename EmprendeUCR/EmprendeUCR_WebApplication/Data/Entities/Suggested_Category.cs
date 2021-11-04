using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Suggested_Category
    {
        [Key]
        /**
        * @brief setter and getter of the Primary Key of suggested category
        */
        public int ID { get; set; }

        /**
        * @brief setter and getter of the Title of the suggested category
        */
        public string Title { get; set; }

        /**
        * @brief setter and getter of the description of a suggested category
        */
        public string Description { get; set; }

        /**
        * @brief setter and getter of the parentId of a category
        */
        public int? ParentID { get; set; }

        /**
        * @brief setter and getter of the description of a category
        */
        public int Status { get; set; }
    }
}

