using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class ClientTest
    {
        [Fact]
        public void TryCreateClient()
        {
            string email = "test@gmail.com";
            Client client = new Client
            {
                User_Email = email,
            };
            Assert.True(email == client.User_Email, "The email is not the same");
        }
    }
}

/*Johel Phillips Ugalde - B75821 Pruebas de Unidad e Integración.
District tests.*/
