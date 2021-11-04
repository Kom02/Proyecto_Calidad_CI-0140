using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using System.Collections.Generic;

namespace EmprendeUCR.Domain.Categories.Entities
{
    public class Category
    {
        public int Id { get; set; }
        //public Products_Service product { get; set; }
        public int ParentId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Product_Service> ProductServices { get; set; }
        public Category(string title, string description, int parentid)
        {
            ParentId = parentid;
            Title = title;
            Description = description;
        }

        // for EFCore
        protected Category()
        {
            Description = null;
            ParentId = 0;
            Title = null;
            ProductServices = null!;
        }

        public void ChangeTitle(string title)
        {
            Title = title;
        }
        public void ChangeDescription(string description)
        {
            Description = description;
        }
        public void ChangeParentId(int parentid)
        {
            ParentId = parentid;
        }
    }
}