using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class LikesTest
    {
        [Fact]
        public void TryCreateLikeComplete()
        {
            string email = "prueba@email.com";
            int category = 0;
            var newLike = new Likes(email, category);

            Assert.True(newLike != null, "The new Likes is equal to null");
        }

        [Fact]
        public void TryCreateLikeEmpty()
        {
            var newLike = new Likes();
            
            Assert.True(newLike != null, "The new Likes is equal to null");
            Assert.True(newLike.Members_Email == null, "The member email is not null");
            Assert.True(newLike.Category_Id == int.MinValue, "The Category id is not min int");
        }

        [Fact]
        public void TrySetEmail()
        {
            string email = "prueba@email.com";
            var newLike = new Likes();
            newLike.Members_Email = email;
            
            Assert.True(email == newLike.Members_Email, "The member email does not the same");
        }

        [Fact]
        public void TrySetCategory()
        {
            int category = 0;
            var newLike = new Likes();
            newLike.Category_Id = category;
            
            Assert.True(newLike.Category_Id == category, "The Category id does not the same");
        }
    }
}

/*
Jostyn Delgado - B82568  ___ Pruebas de Unidad e Integración.
Likes tests.
*/
