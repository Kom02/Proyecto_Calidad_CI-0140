using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EmprendeUCR.IntegrationTests.EmprendeUCR;
using EmprendeUCR_WebApplication;
using System;
using System.Collections.Generic;

namespace EmprendeUCR.IntegrationTests.OrderContext.Infraestructure.Repositories
{
    public class OrderRepositoryIntegrationTest : IClassFixture<ShoppingFactory<Startup>>
    {
        private readonly ShoppingFactory<Startup> _factory;

        public OrderRepositoryIntegrationTest(ShoppingFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TryGetAllOrdersByEmail()
        {
            const int orderCount = 2;
            string entrepreneurEmail = "saguilar1999@hotmail.com";
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            // act
            var orders = await repository.GetByIdAsync(entrepreneurEmail);

            // assert
            orders.Should().HaveCount(orderCount);
        }

        [Fact]
        public async Task TryGetAcceptedOrders()
        {
            const int orderCount = 3;
            string entrepreneurEmail = "saguilar1999@hotmail.com";
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            // act
            var orders = await repository.GetAcceptedOrders(entrepreneurEmail);

            // assert
            orders.Should().HaveCount(orderCount);
        }

        [Fact]
        public async Task TryGetClientOrdersAsync()
        {
            const int orderCount = 5;
            string clientEmail = "juan.valverde@ucr.ac.cr";
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            // act
            var orders = await repository.GetClientOrdersAsync(clientEmail);

            // assert
            orders.Should().HaveCount(orderCount);
        }

        [Fact]
        public async Task TryGetProductsAsync()
        {
            //// arrange
            //const int productCount = 0;

            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "En pendiente de revision");

            //var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            //// act
            //var orders = repository.GetProductsAsync(order);

            //// assert
            //orders.Should().HaveCount(productCount);
        }

        [Fact]
        public async Task TryOrderUpdate()
        {
            // arrange
            string entrepreneurEmail = "saguilar1999@hotmail.com";
            string newStatus = "Aceptado";
            string status = "Pendiente de revision";

            var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            var orders = await repository.GetByIdAsync(entrepreneurEmail);
            var order = orders.FirstOrDefault(s => s.State == status);

            // act
            order.State = newStatus;
            await repository.orderUpdate(order);

            // assert
            order.State.Should().Be(newStatus);
        }

        [Fact]
        public async Task TryDefineColor()
        {
            //// arrange
            //var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            //string expectedColor = "softGreen";

            //var order = new Order(DateTime.Now, "usuario@ucr.ac.cr",
            //    "", DateTime.Now, "emprendedor@ucr.ac.cr", "Aceptado");

            //// act
            //string receivedColor = repository.defineColor(order.State);

            //// assert
            //receivedColor.Should().Be(expectedColor);
        }
        
        [Fact]
        public async Task TryGetOrderStatuses()
        {
            // arrange
            int statusCount = 4;

            var repository = _factory.Server.Services.GetRequiredService<IOrderRepository>();

            List<Status> statuses;

            // act
            statuses = await repository.GetOrderStatuses();
            // assert
            statuses.Count.Should().Be(statusCount);
        }
        


    }
}
