using EmprendeUCR_WebApplication.Data.Entities.ContextShop;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.Repositories;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Application.ShoppingCartContext.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IOfferRepository _offerRepositoy;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IOfferRepository offerRepository )
        {
            _shoppingCartRepository = shoppingCartRepository;
            _offerRepositoy = offerRepository;
        }

        /*
          Summary: Method to delete a line(shopline) from a shopping cart.
          Parameters: Method gets a shopping cart and a shopLine
          Return: Nothing
          Exceptions: There aren't known exceptions
        */
        public async Task DeleteLineFromShoppingCart(ShoppingCart shoppingCart, ShopLine shopLine)
        {
            shoppingCart.DeleteProductFromShoppingCart(shopLine);
            await _shoppingCartRepository.DeleteLine(shopLine);
            await _shoppingCartRepository.SaveAsync(shoppingCart);
        }

        /*
          Summary: Method get the ShoppingCart from an email
          Parameters: Method gets a string representing an email
          Return: Returns the shopping cart associated to the email
          Exceptions: There aren't known exceptions
        */
        public async Task<ShoppingCart?> GetByIdAsync(string email)
        {
            Task<ShoppingCart?> shopping =  _shoppingCartRepository.GetByIdAsync(email);
            List<Offer> offers = await _offerRepositoy.getOffersToShop(DateTime.Now.Date);
            var shop = await shopping;
            foreach (var shopLine in shop.ShopLines) {
                shopLine.product.getCurrentPrice(offers);
            }
            return shop;
        }

        /*
          Summary: Method to load all the photos from all the orders.
          Parameters: Method receives a Product to load its photos.
          Return: Returns a lists of product photos.
          Exceptions: There aren't known exceptions
        */
        public Task<List<Product_Photos>> LoadAllPhotos(Product product)
        {
            return _shoppingCartRepository.GetPhotos(product);
        }

        /*
          Summary: Method to send a request from a shopping cart, with its special requirements and a choosen date.
          Parameters: Method receives shopping cart with its products, a string with special requirements and a date.
          Return: Nothing.
          Exceptions: There aren't known exceptions
        */
        public async Task sendRequest(ShoppingCart shop, string Details, 
                                        string DeliveryAddress, DateTime DeliveryDate, 
                                            string selectedPaymentMethod)
        {
            await _shoppingCartRepository.SendRequest(shop, Details, DeliveryAddress, DeliveryDate, selectedPaymentMethod);
            foreach (var shopLine in shop.ShopLines)
            {
                await _shoppingCartRepository.DeleteLine(shopLine);
            }
            await _shoppingCartRepository.SaveAsync(shop);
            //shop.eraseAllProductLines();
            //await _shoppingCartRepository.SaveAsync(shop);
        }

        /*
          Summary: Method to get all the products called by the pagination system. 
          Parameters: Method receives a ShopParameters indicating what must be paginated and a string email.
          Return: a PagedList object with ShopLines inside.
          Exceptions: There aren't known exceptions
        */
        public async Task<PagedList<ShopLine>> GetProducts(ShopParameters productParameters, string email)
        {
            var _products = await _shoppingCartRepository.GetByIdAsync(email);
            return PagedList<ShopLine>
                .ToPagedList(_products.ShopLines, productParameters.PageNumber, productParameters.PageSize);
        }

    }
}
