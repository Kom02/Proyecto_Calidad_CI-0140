using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Category
    {
        [Key]
        /**
        * @brief setter and getter of the Primary Key of category
        */
        public int Id { get; set; }

        /**
        * @brief setter and getter of the Title of the category
        */
        public string Title { get; set; }

        /**
        * @brief setter and getter of the parentId of a category
        */
        public int? ParentId { get; set; }

        /**
        * @brief setter and getter of the description of a category
        */
        public string Description { get; set; }
    }
}
