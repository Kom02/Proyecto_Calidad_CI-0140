using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Offer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Offer_ID { get; set; }
        public DateTime Initial_Date { get; set; }
        public DateTime Expire_Date { get; set; }
        public string Offer_Description { get; set; }
        [Required]
        public int Discount { get; set; }

        public bool isTypeOfferCombo(List<Is_Offer> relatedIs_Offers)
        {
            // True = Combo
            // False = descuento
            return relatedIs_Offers.Count > 1;
        }

        public bool isValidDate(Offer offer) {

            // If the initial date input is greater than the expire date
            if (offer.Initial_Date > Expire_Date || offer.Expire_Date <= DateTime.Today)
            {
                // throw new NotImplementedException( "La fecha de final de oferta debe ser mayor a la fecha de inicio.");
                return false;
            }
            return true;
        }

        public bool isValidDiscount(Offer offer, List<Product> relatedProducts, List<Service> relatedServices)
        {
            // If the discount is negative or is empty
            if (offer.Discount <= 0 || String.IsNullOrEmpty(offer.Discount.ToString()))
            {
                return false;
            }
            int totalOfTheOfferOriginalAmount = 0;
            // Check if the total sum of the product and services realted to the offer is greater than the discount price

            foreach (var product in relatedProducts)
            {
                totalOfTheOfferOriginalAmount += product.Price;
            }

            foreach (var service in relatedServices)
            {
                totalOfTheOfferOriginalAmount += service.Price_per_hour;
            }

            if (totalOfTheOfferOriginalAmount < offer.Discount)
            {
                return false;
            }

            return true;
        }
    }
}
