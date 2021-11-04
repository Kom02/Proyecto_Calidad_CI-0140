using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;
using EmprendeUCR_WebApplication.Data.Entities.ContextShop;

namespace EmprendeUCR_WebApplication.Application.ShoppingCartContext
{
    // Interface implementation for the ShoppingCart
    interface IShoppingCartService
    {
        // Interface declaration methods for the ShoppingCart 
        Task<ShoppingCart?> GetByIdAsync(string email);
        Task DeleteLineFromShoppingCart(ShoppingCart shoppingCart, ShopLine shopLine);
        Task <List<Product_Photos>> LoadAllPhotos(Product product);

        //Task orderRequest(ShoppingCart shop);

        Task<PagedList<ShopLine>> GetProducts(ShopParameters productParameters, string email);
        Task sendRequest(ShoppingCart shop, string Details, 
                            string DeliveryAddress, DateTime DeliveryDate, 
                                string selectedPaymentMethod);
    }
}
