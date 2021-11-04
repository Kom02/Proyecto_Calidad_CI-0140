using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class CredentialsTest
    {
        [Fact]
        public void TryCreateCredentials()
        {
            string email = "Jorge@.com";
            string password = "Hola12.-";
            Credentials credentials = new Credentials
            {
                User_Email = email,
                Password = password
            };
            Assert.True(email == credentials.User_Email, "The email does not the same"); 
            Assert.True(password == credentials.Password, "The password does not the same");
        }
    }
}
/*
Jostyn Delgado - B82568  ___ Pruebas de Unidad e Integración.
Credentials tests.
*/

