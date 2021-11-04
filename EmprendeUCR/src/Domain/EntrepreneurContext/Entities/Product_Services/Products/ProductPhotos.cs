using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products
{
    public class ProductPhotos
    {
        [Key]
        public int Product_Photos_ID { get; set; }
        public Product Product { get; set; }
        public byte[] Photos { get; set; }

        public int Code_ID { get; set; }

        //FK
        public Product product;
        private ProductPhotos()
        {
        }
    }
}
