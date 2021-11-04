using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class DistrictTest
    {
        [Fact]
        public void TryCreateDistrict()
        {
            string name = "Heredia";
            District district = new District
            {
                Name = name,
                Province_Name = name,
                Canton_Name = name
            };
            Assert.True(name == district.Name, "The district name is not the same");
            Assert.True(name == district.Province_Name, "The province name is not the same");
            Assert.True(name == district.Canton_Name, "The canton name is not the same");
        }
    }
}

/*Johel Phillips Ugalde - B75821 Pruebas de Unidad e Integración.
District tests.*/
