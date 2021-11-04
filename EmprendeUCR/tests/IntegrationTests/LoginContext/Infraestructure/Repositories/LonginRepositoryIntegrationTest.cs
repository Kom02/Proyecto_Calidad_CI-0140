using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR.Domain.RegisterContext.Entities;
using EmprendeUCR.Domain.RegisterContext.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EmprendeUCR_WebApplication;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.LoginContext.Repositories;

namespace EmprendeUCR.IntegrationTests.LoginContext.Infraestructure.Repositories
{
    public class LonginRepositoryIntegrationTest : IClassFixture<LoginContextFactory<Startup>>
    {
        private readonly LoginContextFactory<Startup> _factory;
        public LonginRepositoryIntegrationTest(LoginContextFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task verifyUserNotFoundClient()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findClient = await repository.verifyUserType("luis.valverde@ucr.ac.cr", 1);
            findClient.Should().BeFalse();

        }

        [Fact]
        public async Task verifyUserFoundClient()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findClient = await repository.verifyUserType("juan.valverde@ucr.ac.cr", 1);
            findClient.Should().BeTrue();
        }

        [Fact]
        public async Task verifyUserNotFoundEntrepreneur()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findClient = await repository.verifyUserType("luisaguilar1999@hotmail.com", 2);
            findClient.Should().BeFalse();
        }

        [Fact]
        public async Task verifyUserFoundEntrepreneur()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findClient = await repository.verifyUserType("saguilar1999@hotmail.com", 2);
            findClient.Should().BeTrue();
        }

        [Fact]
        public async Task verifyUserNotFoundAdministrator()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findClient = await repository.verifyUserType("luisAdmin@hotmail.com", 3);
            findClient.Should().BeFalse();
        }

        [Fact]
        public async Task verifyUserFoundAdministrator()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findClient = await repository.verifyUserType("cuenta.admin@gmail.com", 3);
            findClient.Should().BeTrue();
        }

        [Fact]
        public async Task verifyNotFoundPassword()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findCredentials = await repository.GetPassword("cuenta.admin@gmail.com");
            findCredentials.Should().Be("");
        }

        [Fact]
        public async Task VerifyFoundPassword()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findCredentials = await repository.GetPassword("juan.valverde@ucr.ac.cr");
            findCredentials.Should().Be("contraJuan");
        }

        [Fact]
        public async Task VerifyNotFoundEmailConfirmation() 
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findEmail = await repository.GetEmailConfirmationByEmail("juanLuis.valverde@ucr.ac.cr");
            findEmail.Should().BeNull();
        }

        [Fact]
        public async Task VerifyFoundEmailConfirmation()
        {
            var repository = _factory.Server.Services.GetRequiredService<ILoginRepository>();
            var findEmail = await repository.GetEmailConfirmationByEmail("juan.valverde@ucr.ac.cr");
            findEmail.Should().NotBeNull();
        }
    }
}
