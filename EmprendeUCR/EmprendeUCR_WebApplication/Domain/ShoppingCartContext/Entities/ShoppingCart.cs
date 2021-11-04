using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using System;
using System.Collections.Generic;

/* This file is used to map the "Shopping_Cart" table and to used as a
 * ShoppingCart entity.
 */
namespace EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities
{
    public partial class ShoppingCart : AggregateRoot
    {
        // Atribbutes to make mapping on ShoppingCart as Shopping_Cart (Table).
        private readonly List<ShopLine> _shopLines;
        public string Email { get; set; }

        public IReadOnlyCollection<ShopLine> ShopLines => _shopLines.AsReadOnly();

        /* Summary: Delete a specific shopLine from a shopping cart.
         * Parameters: Receives the shopLine to be deleted.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        internal void DeleteProductFromShoppingCart(ShopLine shopLine)
        {
            if (_shopLines.Exists(p => p == shopLine))
            {
                _shopLines.Remove(shopLine);
            }
        }

        /* Summary: Delete all the shopLines from a shopping cart.
         * Parameters: None.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        internal void eraseAllProductLines() {
            foreach (var shopLine in ShopLines) {
                DeleteProductFromShoppingCart(shopLine);
            }
        }
    }
}
