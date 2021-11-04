using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;
using System;
using System.Collections.Generic;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

/* This file is used to map the "Shopping_Cart_Has" table and to used as a 
 * ShopLine entity.
 */
namespace EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities
{
    public partial class ShopLine
    {
        // Atribbutes to make mapping on shopLine as Shopping_Cart_Has (Table).
        public string Email { get; set; }
        public int CodeId { get; set; }
        public string EntrepreneurEmail { get; set; }
        public int CategoryId { get; set; }
        public ShoppingCart shoppingCart { get; set; }

        // It is going to be used to access to the name and price of every
        // line.
        public Product product { get; set; }
        public int Quantity { get; set; } = 1;

    }
}