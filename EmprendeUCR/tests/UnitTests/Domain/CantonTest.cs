/*
Luis Eduardo Rojas Carrillo - B86875 Pruebas de Unidad e Integración.
Kevin Obando Molina - B55121
Canton tests.
*/
using FluentAssertions;
using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class CantonTest
    {
        [Fact]
        public void TryCreateCanton() 
        {
            var newCanton = new Canton("Agua Caliente", "Cartago");
            Assert.Equal("Agua Caliente", newCanton.Name); //Get and test Set
            Assert.Equal("Cartago", newCanton.Province_Name); //Get and test Set
        }

        [Fact]
        public void TrySetCantonName()
        {
            var newCanton = new Canton();
            newCanton.Name = "San José";
            Assert.Equal("San José", newCanton.Name); //Get and test Set
        }

        [Fact]
        public void TrysetCantonNameProvince()
        {
            var newCanton = new Canton();
            newCanton.Province_Name = "San José";
            Assert.Equal("San José", newCanton.Province_Name); //Get and test Set
        }
    }
}
