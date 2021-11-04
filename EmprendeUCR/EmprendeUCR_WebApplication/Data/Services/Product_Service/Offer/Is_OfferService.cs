using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Is_OfferService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Is_OfferService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Is_Offer>> GetAsync()    // Enlista Ofertas
        {
            return await _context.Is_Offer.ToListAsync();
        }

        public async Task<bool> InsertIs_OfferAsync(Is_Offer offer) // Agrega Ofertas
        {
            await _context.Is_Offer.AddAsync(offer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertListOfIs_Offer(IList<Is_Offer> Is_offerList) // Agrega Ofertas
        {
            try
            {
                foreach (var offer in Is_offerList)
                {
                   await InsertIs_OfferAsync(offer);
                } 
                await _context.SaveChangesAsync();
            }
            catch(InvalidOperationException)
            {
                
            }

            return true;
        }


        public async Task<bool> UpdateIs_OfferAsync(Is_Offer offer) // Update Ofertas
        {

            _context.Is_Offer.Update(offer);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteIs_OfferAsync(Is_Offer offer) // Eliminar Ofertas
        {
            _context.Is_Offer.Remove(offer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIs_OfferRelatedToOfferAsync(List<Is_Offer> relatedIsOffers) // Eliminar Ofertas
        {

           foreach(var is_offer in relatedIsOffers)
            {
                await DeleteIs_OfferAsync(is_offer);
            }
            return true;
        }


        public async Task<Is_Offer> GetIs_OfferAsync(int Is_Offer_Id)
        {
            Is_Offer offer = await _context.Is_Offer.FirstOrDefaultAsync(c => c.Offer_ID.Equals(Is_Offer_Id));

            return offer;
        }


        public async Task<List<Is_Offer>> GetAllIs_OffersAsync()
        {

            return await _context.Is_Offer.ToListAsync();        // Listado 2
        }

        public async Task<Product> GetProductRelatedAsync(Is_Offer is_offer)
        {
            return await _context.Product.FirstOrDefaultAsync(product => String.Equals(product.Code_ID, is_offer.Code_ID));
        }

        public async Task<Service> GetServiceRelatedAsync(Is_Offer is_offer)
        {
            return await _context.Service.FirstOrDefaultAsync(service => String.Equals(service.Code_ID, is_offer.Code_ID));
        }

        public Product GetProductRelated(Is_Offer is_offer)
        {
            return _context.Product.FirstOrDefault(product => String.Equals(product.Code_ID, is_offer.Code_ID));
        }

        public Service GetServiceRelated(Is_Offer is_offer)
        {
            return _context.Service.FirstOrDefault(service => String.Equals(service.Code_ID, is_offer.Code_ID));
        }
        

        public Is_Offer GetIs_Offer(int Is_Offer_Id)
        {
            Is_Offer offer = _context.Is_Offer.FirstOrDefault(c => c.Offer_ID.Equals(Is_Offer_Id));

            return offer;
        }
    }

}

