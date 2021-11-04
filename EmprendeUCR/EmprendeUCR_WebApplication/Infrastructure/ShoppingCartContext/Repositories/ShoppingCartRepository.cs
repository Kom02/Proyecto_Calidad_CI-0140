using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.Repositories;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;
using EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext;
using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;

/* This file is used to implement the methods used by queries to take, enter or
 * change data in the EmprendeUCR database, in the context of the Shopping Cart.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.Core
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartDbContext2 _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        /* Summary: Take the data base, in the context of the shopping cart, 
         *          and assigns it to the _dbContext varible to use it in the 
         *          future.
         * Parameters: Receives the data base, in the context of the orders.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public ShoppingCartRepository(ShoppingCartDbContext2 unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /* Summary: Delete a shop line.
         * Parameters: Receives the shop line to be deleted.
         * Return: A task.
         * Exceptions: There aren't known exceptions.
        */
        public Task DeleteLine(ShopLine shopLine)
        {
            _dbContext.ShopLines.Remove(shopLine);
            return Task.CompletedTask;
        }

        /* Summary: Gets the shopping cart related to a specific user email.
         * Parameters: Receives the email to search the shopping cart.
         * Return: A ShoppingCart.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<ShoppingCart?> GetByIdAsync(string email)
        {
            ShoppingCart shop = await _dbContext.ShoppingCarts
               .Include(shop => shop.ShopLines)
                    .ThenInclude(p => p.product)
                    .ThenInclude(p => p.Product_Photos)
               .FirstOrDefaultAsync(t => t.Email == email);
            return shop;
        }

        /* Summary: Save the changes of a shopping cart.
         * Parameters: Receives the shopping cart to be saved.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public async Task SaveAsync(ShoppingCart shoppingCart)
        {
            _dbContext.Update(shoppingCart);

            await _dbContext.SaveEntitiesAsync();
        }

        /* Summary: Gets the photos of a product.
         * Parameters: Receives the product to search for his photos.
         * Return: A list of Product_Photos.
         * Exceptions: There aren't known exceptions.
        */
        public async Task< List<Product_Photos>> GetPhotos(Product products)
        {
            List<Product_Photos> photos =  _dbContext.Product_Photos
                 .Where(p => p.Code_ID == products.CodeId)
                 .ToList();
            return products.Product_Photos.ToList();
        }

        /* Summary: Send a order created from a shopping cart.
         * Parameters: Receives the shopping cart, the details and the delivery
         *             date of the order to be created.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public async Task SendRequest(ShoppingCart shop, string Details, string DeliveryAddress, 
                                                DateTime DeliveryDate, string selectedPaymentMethod)
        {
            Order order =  await CreateOrder(shop, Details, DeliveryAddress, DeliveryDate, selectedPaymentMethod);
            await _dbContext.SaveEntitiesAsync();
        }

        /* Summary: Create a order from a shopping cart with his own details
         *          and delivery date.
         * Parameters: Receives the shopping cart, the details and the delivery
         *             date of the order to be created.
         * Return: A order.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<Order> CreateOrder(ShoppingCart shop, string Details, 
                         string DeliveryAddress, DateTime DeliveryDate, string selectedPaymentMethod )
        {
            DateTime DateAndHourCreation = DateTime.Now;
            DateAndHourCreation = new DateTime(
            DateAndHourCreation.Ticks - (DateAndHourCreation.Ticks % TimeSpan.TicksPerSecond),
            DateAndHourCreation.Kind);

            string ClientEmail = shop.Email;
            string EntrepreneurEmail = shop.ShopLines.FirstOrDefault().EntrepreneurEmail;
            string status = "Pendiente de revision";
            List<Organized> listShopLine = new List<Organized>();

            Order order = new Order(DateAndHourCreation, ClientEmail, Details, DeliveryAddress, DeliveryDate,
                          EntrepreneurEmail, status, selectedPaymentMethod);
            foreach (var organizedLine in shop.ShopLines)
            {
                int codeId = organizedLine.CodeId;
                int categoryId = organizedLine.CategoryId;
                int quantity = organizedLine.Quantity;
                EntrepreneurEmail = organizedLine.EntrepreneurEmail;
                Organized organized = new Organized(codeId, EntrepreneurEmail, categoryId, 
                        DateAndHourCreation,ClientEmail, status, quantity, DeliveryDate, order);
                listShopLine.Add(organized);
            }
            order.setOrganized(listShopLine);
            _dbContext.Add(order);
            return order;           
        }

    }
       
}
