using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR.Domain.HomePageClientContext.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EmprendeUCR_WebApplication;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.IntegrationTests.HomePageClientContext.Infraestructure.Repositories
{
    public class HomePageRepositoryIntegrationTest : IClassFixture<HomePageClientContextFactory<Startup>> 
    {
        private readonly HomePageClientContextFactory<Startup> _factory;

       HomePageRepositoryIntegrationTest(HomePageClientContextFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task getProductsByInput()
        {
            var repository = _factory.Server.Services.GetRequiredService<IHomePageClientRepository>();
            var products =  repository.getNewProducts();

        }

    }
}
