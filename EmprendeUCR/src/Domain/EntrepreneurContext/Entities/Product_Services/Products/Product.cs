using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using EmprendeUCR.Domain.Entrepreneurs.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Categories.Entities;

namespace EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products
{
    public class Product
    {

        public int Code_ID { get; set; }
        public RequiredProductName Product_Name { get; set; }
        public RequiredProductDescription Product_Description { get; set; }
        public int Price { get; set; }

        //public Product_Service Product_Service { get; set; }

        public IEnumerable<ProductPhotos> Photos { get; set; }

        // code
        // correo emprendedor
        // categoria

        // code id
        // entrepre
        // availa
        // category

        // fotos
        // ofertas
        // supplies
        // keywords
        // estados

        // addPhotoToProduct

        // addSupplyToProduct

        // addCategoryToProduct

        //

        private Product()
        {
            Product_Name = null!;
            Product_Description = null!;
            Price = 0!;
            //Product_Service = null!;
            Photos = null!;
        }


        //public Product(Entrepreneur entrepreneur,
        //    Category category,
        //    Boolean availability,
        //    RequiredProductName name,
        //    RequiredProductDescription description,
        //    int price) : base(entrepreneur, category, availability)
        //{
        //    Product_Name = name;
        //    Product_Description = description;
        //    Price = price;
        //}
    }
}


