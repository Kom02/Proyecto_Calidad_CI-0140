/*
 * Diego Barquero Quesada
 * B80961
 * Pruebas de Unidad e Integración.
 * Phones Test
 * */
using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class PhonesTest
    {
        [Fact]
        public void TryCreatePhones()
        {
            string userEmail = "Carlos@.com";
            string phone = "8888-8888";

            Phones myPhone = new Phones
            {
                User_Email = userEmail,
                Phone_Number = phone
            };
           
            Assert.True(userEmail == myPhone.User_Email, "The user email is not the same");
            Assert.True(phone == myPhone.Phone_Number, "The user phone is not the same");

        }
    }
}
