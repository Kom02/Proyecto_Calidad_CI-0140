using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

/* This file is used to map the "Product_Service" table and to used as a 
 * ProductService entity.
 */
namespace EmprendeUCR_WebApplication.Domain.Core.CoreEntities
{
    public class ProductService
    {
        public int CodeId { get; set; }
        public string EntrepreneurEmail { get; set; }
        public byte Availability { get; set; }
        public int CategoryId { get; set; }

        /*
          Summary: This method takes an order and search for the 
                   correspondant status of this product, related to
                   that order.
          Parameters: Method recieves an Order Object.
          Return: A string.
          Exceptions: There aren't known exceptions
        */
        public string GetProductStatus(Order order)
        {
            string state = this.Organized.Where(item => item.DateAndHourCreation == order.DateAndHourCreation
                                       && item.Email == order.ClientEmail).First().Name;

            return state;
        }

        // Foreign entities
        private readonly List<Organized> _organizedList;
        public IReadOnlyCollection<Organized> Organized;
        private readonly List<ProductHasStatus> _productHasStatusList;
        public IReadOnlyCollection<ProductHasStatus> ProductHasStatus;
        private readonly List<ShopLine> shoppingCartHas;
        public IReadOnlyCollection<ShopLine> ShoppingCartHas => shoppingCartHas.AsReadOnly();
    }
}
