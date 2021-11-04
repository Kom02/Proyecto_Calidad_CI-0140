using Xunit;
using System;
using EmprendeUCR_WebApplication.Data.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.UnitTests.Domain
{
    public class OfferTest
    {
        [Fact]
        public void tryCreateEmpty()
        {
            var newOffer = new Offer();
            Assert.True(newOffer != null);
            Assert.True(newOffer.Discount == 0);
            Assert.False(newOffer.Expire_Date == null);
            Assert.False(newOffer.Initial_Date == null);
            Assert.True(newOffer.Offer_Description == null);
        }
        [Fact]
        public void trySetDiscount()
        {
            var newOffer = new Offer();
            newOffer.Discount = 100;
            Assert.True(newOffer.Discount >= 0);
            Assert.True(newOffer.Discount != null);
        }
        [Fact]
        public void trySetInitialDate()
        {
            var newOffer = new Offer();
            newOffer.Initial_Date = DateTime.Today;
            Assert.True(newOffer.Initial_Date != null);
        }
        [Fact]
        public void trySetExpireDate()
        {
            var newOffer = new Offer();
            newOffer.Initial_Date = DateTime.Today;
            Assert.True(newOffer.Expire_Date != null);
        }
        [Fact]
        public void testTypeOffer()
        {
            /*
              PIIB12021-467 on PIIB12021-343 Modify offers with the allies
              Driver: Rafael Porras
              Copilot: Andres Chaves
            */
            // test products
            Product product1 = new();
            Product product2 = new();
            Product product3 = new();
            product1.Code_ID = 1;
            product1.Product_Name = "Cafe";
            product1.Price = 800;
            product2.Code_ID = 2;
            product2.Product_Name = "Queque";
            product2.Price = 500;
            product3.Code_ID = 3;
            product3.Product_Name = "Empanada";
            product3.Price = 700;

            // test isoffers
            // combo
            Is_Offer isoffer1 = new();
            isoffer1.Offer_ID = 1;
            isoffer1.Code_ID = 1;
            isoffer1.Amount = 1;
            Is_Offer isoffer2 = new();
            isoffer2.Offer_ID = 1;
            isoffer2.Code_ID = 2;
            isoffer2.Amount = 1;

            // descuento
            Is_Offer isoffer3 = new();
            isoffer3.Offer_ID = 1;
            isoffer3.Code_ID = 1;
            isoffer3.Amount = 3;


            // test offers
            Offer offer1 = new(); // combo
            Offer offer2 = new(); // descuento

            offer1.Discount = 1000;
            offer2.Discount = 1500;

            List<Is_Offer> relatedIs_Offers = new List<Is_Offer>();
            relatedIs_Offers.Add(isoffer1);
            relatedIs_Offers.Add(isoffer2);

            List<Is_Offer> relatedIs_Offers2 = new List<Is_Offer>();
            relatedIs_Offers.Add(isoffer3);

            Assert.True(offer1.isTypeOfferCombo(relatedIs_Offers));
            Assert.False(offer2.isTypeOfferCombo(relatedIs_Offers2));
        }
        /*
         PIIB12021-467 on PIIB12021-343 Modify offers with the allies
         Driver: Rafael Porras
         Copilot: Andres Chaves
         */
        [Fact]
        public void testOffersDates()
        {
            // test offers
            Offer offer1 = new();
            offer1.Initial_Date = DateTime.Today;
            offer1.Expire_Date = DateTime.Parse("2998-06-25");
            // Initial date <= expire date
            Offer offer2 = new();
            offer2.Initial_Date = DateTime.Now;
            offer2.Expire_Date = DateTime.Parse("2998-06-25");
            // expire date > Today
            Offer offer3 = new();
            offer3.Initial_Date = DateTime.Today;
            offer3.Expire_Date = DateTime.Parse("1998-06-25");

            Assert.True(offer1.isValidDate(offer1));
            Assert.True(offer2.isValidDate(offer2));
            Assert.False(offer3.isValidDate(offer2));

        }
        [Fact]

        public void testOffersDiscount()
        {
            // Discount must be greater than 0
            Offer offer1 = new();
            List<Product> productsRelated1 = new List<Product>();
            List<Service> servicesRelated1 = new List<Service>();
            offer1.Discount = 3;
            Assert.False(offer1.isValidDiscount(offer1, productsRelated1, servicesRelated1));

            // Sum must be less than discount
            Product product1 = new();
            Product product2 = new();
            Product product3 = new();
            product1.Code_ID = 1;
            product1.Product_Name = "Cafe";
            product1.Price = 800;
            productsRelated1.Add(product1);
            product2.Code_ID = 2;
            product2.Product_Name = "Queque";
            product2.Price = 500;
            productsRelated1.Add(product2);
            product3.Code_ID = 3;
            product3.Product_Name = "Empanada";
            product3.Price = 700;
            productsRelated1.Add(product3);

            Offer offer2 = new();
            offer2.Discount = 2100;
            Assert.False(offer2.isValidDiscount(offer2, productsRelated1, servicesRelated1));
        }
    }
}
