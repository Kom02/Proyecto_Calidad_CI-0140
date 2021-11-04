using Xunit;
using System;
using EmprendeUCR_WebApplication.Data.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.UnitTests.Domain
{
    public class Is_OfferTest
    {
        [Fact]
        public void tryCreateEmpty()
        {
            var isOffer = new Is_Offer();
            Assert.True(isOffer != null);
            Assert.True(isOffer.Amount == 0);
            Assert.True(isOffer.Category_ID == 0);
            Assert.True(isOffer.Code_ID == 0);
            Assert.True(isOffer.Offer_ID == 0);
            Assert.True(isOffer.User_Email == null);
        }
        [Fact]
        public void trySetAmount()
        {
            var isOffer = new Is_Offer();
            Assert.True(isOffer.Amount == 0);
            isOffer.Amount = 100;
            Assert.True(isOffer.Amount >= 0);
            Assert.True(isOffer.Amount != null);
        }
        [Fact]
        public void trySetCategory()
        {
            var isOffer = new Is_Offer();
            Assert.True(isOffer.Category_ID == 0);
            isOffer.Category_ID = 1;
            Assert.True(isOffer.Category_ID >= 0);
            Assert.True(isOffer.Category_ID != null);
        }
        [Fact]
        public void trySetEmail()
        {
            var isOffer = new Is_Offer();
            Assert.True(isOffer.User_Email == null);
            isOffer.User_Email = "asdada@gmail.com";
            Assert.True(isOffer.User_Email != null);

        }

        
    }
}
