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
namespace EmprendeUCR_WebApplication.Infrastructure.Core.OfferContext.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly OfferDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        /* Summary: Take the data base, in the context of the shopping cart, 
         *          and assigns it to the _dbContext varible to use it in the 
         *          future.
         * Parameters: Receives the data base, in the context of the orders.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public OfferRepository(OfferDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /* Summary: Send a order created from a shopping cart.
         * Parameters: Receives the shopping cart, the details and the delivery
         *             date of the order to be created.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public async Task<List<Offer>> getOffersToShop(DateTime dateTime)
        {
            List<Offer> offer = _dbContext.Offers
                .Include(offer => offer.IsOffers)
                .Where(offer => offer.ExpireDate >= dateTime && offer.InitialDate <= dateTime)
                .ToList();
            offer = offer.Where(o => o.IsOffers.Count == 1).ToList();
            return offer;
        }


        List<Offer> IOfferRepository.getOffersToOrder(DateTime dateTime)
        {
            List<Offer> offer = _dbContext.Offers
                 .Include(offer => offer.IsOffers)
                 .Where(offer => offer.ExpireDate >= dateTime && offer.InitialDate <= dateTime)
                 .ToList();
            offer = offer.Where(o => o.IsOffers.Count == 1).ToList();
            return offer;
        }
    }
}
       

