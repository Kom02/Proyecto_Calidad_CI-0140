using FluentAssertions;
using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using Xunit;
using System.Collections.Generic;
using System;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmprendeUCR.UnitTests.Domain.OrderContext.Entities
{
    public class OrderTests
    {
        [Fact]
        public void TryChangerOrderStatus()
        {
            //// arrange
            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "En pendiente de revision");
            //string state = "Rechazado";

            //// act
            //order.ChangerOrderStatus(state);

            //// assert
            //order.State.Should().Be(state);
        }

        [Fact]
        public void TrySetOrganizedCollection()
        {
            //// arrange
            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "En pendiente de revision");

            //var organized = new Organized(1, "emprendedor@ucr.ac.cr", 2,
            //    DateTime.Now, "usuario@ucr.ac.cr", "",
            //    1, DateTime.Now, order);

            //List<Organized> organizedList = new List<Organized>();
            //organizedList.Add(organized);

            //// act
            //order.setOrganized(organizedList);

            //// assert
            //order.Organized.Should().Equal(organizedList);
        }

        [Fact]
        public void TryChangerOrderStatusDifPath()
        {
            //// arrange
            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "En pendiente de revision");

            //var organized = new Organized(1, "emprendedor@ucr.ac.cr", 2,
            //    DateTime.Now, "usuario@ucr.ac.cr", "",
            //    1, DateTime.Now, order);

            //List<Organized> organizedList = new List<Organized>();
            //organizedList.Add(organized);
            //order.setOrganized(organizedList);
            //string state = "Terminado";

            //// act
            //order.ChangerOrderStatus(state);

            //// assert
            //foreach (var v in order.Organized) { 

            //    v.Name.Should().Be(state);
            //}

        }        
        
        [Fact]
        public void TrychangeProductStatus()
        {
            //// arrange
            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "En pendiente de revision");

            //var organized = new Organized(1, "emprendedor@ucr.ac.cr", 2,
            //    DateTime.Now, "usuario@ucr.ac.cr", "",
            //    1, DateTime.Now, order);

            //List<Organized> organizedList = new List<Organized>();
            //organizedList.Add(organized);
            //order.setOrganized(organizedList);


            //string state = "Terminado";

            //// act
            //order.changeProductStatus(state , 1, "emprendedor@ucr.ac.cr" , 2);

            //// assert
            //var product = order.Organized.FirstOrDefault(p => p.CodeId == 1 && p.EntrepreneurEmail == "emprendedor@ucr.ac.cr" && p.CategoryId == 2);
            //product.Name.Should().Be(state);

        }
    }
}
