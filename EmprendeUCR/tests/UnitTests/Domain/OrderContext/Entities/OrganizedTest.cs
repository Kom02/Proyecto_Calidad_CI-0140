using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using FluentAssertions;

namespace EmprendeUCR.UnitTests.Domain.OrderContext.Entities
{
    public class OrganizedTest
    {
        [Fact]
        public void TryChangeStatus()
        {
            //// arrange

            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "En pendiente de revision");

            //var organized = new Organized(1, "emprendedor@ucr.ac.cr", 2,
            //                DateTime.Now, "usuario@ucr.ac.cr", "Aceptado",
            //                1, DateTime.Now, order);

            //string state = "Rechazado";

            //// act
            //organized.ChangeStatus(state);

            //// assert
            //organized.Name.Should().Be(state);
        }
    }
}
