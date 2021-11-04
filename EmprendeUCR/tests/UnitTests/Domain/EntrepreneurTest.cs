using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class EntrepreneurTest
    {
        [Fact]
        public void TryCreateEntrepreneur()
        {
            string email = "Jorge@.com";
            string presentation = "Hola este es mi presentación";
            Entrepreneur entrepreneur = new Entrepreneur
            {
                User_Email = email,
                Presentation = presentation
            };
            Assert.True(email == entrepreneur.User_Email, "The email does not the same");
            Assert.True(presentation == entrepreneur.Presentation, "The presentation does not the same");
        }
    }
}

/*
Jostyn Delgado - B82568  ___ Pruebas de Unidad e Integración.
Entrepreneur tests.
*/