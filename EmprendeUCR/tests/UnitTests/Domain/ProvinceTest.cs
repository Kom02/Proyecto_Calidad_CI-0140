using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class ProvinceTest
    {
        [Fact]
        public void TryCreateProvince()
        {
            string provinceName = "Heredia";
            Province province = new Province
            {
                Name = provinceName
            };
            Assert.True(provinceName == province.Name, "The province name is not the same");
        }
    }
}

/*Johel Phillips Ugalde - B75821 Pruebas de Unidad e Integración.
Province tests.*/
