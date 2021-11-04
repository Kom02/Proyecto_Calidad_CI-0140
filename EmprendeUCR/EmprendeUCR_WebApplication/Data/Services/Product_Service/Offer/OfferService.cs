using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class OfferService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public OfferService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Offer>> GetAsync()    // Enlista Ofertas
        {
            return await _context.Offer.ToListAsync();
        }

        public async Task<int> InsertOfferAsync(Offer offer) // Agrega Ofertas
        {
            Offer obj = offer;
            await _context.Offer.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.Offer_ID;
        }



        public async Task<bool> UpdateOfferAsync(Offer offer) // Update Ofertas
        {

            _context.Offer.Update(offer);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteOfferAsync(Offer offer) // Eliminar Ofertas
        {
            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<Offer> GetOfferAsync(int Offer_Id)
        {

            Offer offer = await _context.Offer.FirstOrDefaultAsync(o => o.Offer_ID.Equals(Offer_Id));
            return offer;

        }


        public async Task<List<Offer>> GetAllOffersAsync()
        {

            return await _context.Offer.ToListAsync();        // Listado 2
        }

        public async Task<List<Is_Offer>> GetAllIs_OfferRelatedToOffer(Offer offer)
        {
            return await _context.Is_Offer.Where(is_Offer => String.Equals(offer.Offer_ID, is_Offer.Offer_ID)).ToListAsync();
        }

        public List<Is_Offer> GetAllIs_OfferRelatedToOfferNOTAsync(Offer offer)
        {
            return _context.Is_Offer.Where(is_Offer => String.Equals(offer.Offer_ID, is_Offer.Offer_ID)).ToList();
        }

        public List<Offer> GetOfferFromEntrepreneur(string email)
        {
            List<Offer> relatedOffers = new List<Offer>();
            // Filtra los is_offer ligados al email
            var is_offers = _context.Is_Offer.Where(c => String.Equals(c.User_Email, email)).ToList();
            // Consiue todos los offers ligados a 
            foreach (var is_offer in is_offers)
            {
                var relatedOffer = _context.Offer.FirstOrDefault(c => String.Equals(c.Offer_ID, is_offer.Offer_ID));
                var alreadyAdded = relatedOffers.FirstOrDefault(c => String.Equals(c.Offer_ID, relatedOffer.Offer_ID));
                if (alreadyAdded is null)
                {
                    relatedOffers.Add(relatedOffer);
                }
            }
            return relatedOffers;
        }

        public bool hasCommonOffers(string firstEntrepreneur, string secondEntrepreneur)
        {
            bool hasCommonOffers = false;
            // Get entrepreneurs offers
            List<Offer> firstEntrepreneurOffers = GetOfferFromEntrepreneur(firstEntrepreneur);
            List<Offer> secondEntrepreneurOffers = GetOfferFromEntrepreneur(secondEntrepreneur);
            List<Is_Offer> is_OffersIntoOffer = new List<Is_Offer>();
            // Check first entrepreneur offers
            foreach (var offer in firstEntrepreneurOffers)
            {
                is_OffersIntoOffer = GetAllIs_OfferRelatedToOfferNOTAsync(offer);
                foreach (var is_offer in is_OffersIntoOffer)
                {
                    hasCommonOffers = is_offer.User_Email == secondEntrepreneur;
                    // If my offer has the secondEntrepreneur email associated to a product in the offer
                    if (hasCommonOffers)
                    {
                        return true;
                    }
                }
            }
            // Check second  entrepreneur offers
            foreach (var offer in secondEntrepreneurOffers)
            {
                is_OffersIntoOffer = GetAllIs_OfferRelatedToOfferNOTAsync(offer);
                foreach (var is_offer in is_OffersIntoOffer)
                {
                    hasCommonOffers = is_offer.User_Email == firstEntrepreneur;
                    // If my offer has the firstEntrepreneur email associated to a product in the offer
                    if (hasCommonOffers)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}

