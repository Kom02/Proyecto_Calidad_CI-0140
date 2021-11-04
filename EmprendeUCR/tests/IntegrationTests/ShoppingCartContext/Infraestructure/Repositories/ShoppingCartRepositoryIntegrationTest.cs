using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EmprendeUCR.IntegrationTests.EmprendeUCR;
using EmprendeUCR_WebApplication;
using System;
using System.Collections.Generic;
using EmprendeUCR_WebApplication.Data.Entities;

namespace EmprendeUCR.IntegrationTests.ShoppingCartContext.Infraestructure.Repositories
{
    public class ShoppingCartRepositoryIntegrationTest : IClassFixture<ShoppingFactory<Startup>>
    {
        private readonly ShoppingFactory<Startup> _factory;

        public ShoppingCartRepositoryIntegrationTest(ShoppingFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TryGetByIdAsync()
        {
            // arrange
            string email = "juan.valverde@ucr.ac.cr";
            var repository = _factory.Server.Services.GetRequiredService<IShoppingCartRepository>();

            // act
            var shopping = await repository.GetByIdAsync(email);

            // assert
            shopping.Should().NotBeNull();
        }

    }
}
