using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;

/* This file is used as a interface of the file ShoppingCartRepository.
 */
namespace EmprendeUCR_WebApplication.Domain.Repositories
{
    public interface  IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task SaveAsync(ShoppingCart shoppingCart);
        Task<ShoppingCart?> GetByIdAsync(string email);
        Task DeleteLine(ShopLine line);
        Task<List<Product_Photos>> GetPhotos(Product product);
        Task SendRequest(ShoppingCart shop, string Details, string DeliveryAddress, 
                                        DateTime DeliveryDate, string selectedPaymentMethod);
        Task<Order> CreateOrder(ShoppingCart shop, string Details, string DeliveryAddress, 
                                        DateTime DeliveryDate, string selectedPaymentMethod);
    }
}
