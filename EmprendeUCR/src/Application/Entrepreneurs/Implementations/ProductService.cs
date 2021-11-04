using EmprendeUCR.Domain.EntrepreneurContext.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.Entrepreneurs.Implementations
{
    class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //public async Task AddPlayerToTeamRosterAsync(Team team, Player player)
        //{
        //    player.AssignTeam(team);
        //    team.AddPlayerToRoster(player);

        //    await _teamRepository.SaveAsync(team);
        //}

        //public async Task DeletePlayerAndRemoveFromTeamRosterAsync(Team team, Player player)
        //{
        //    team.RemovePlayerFromRoster(player);
        //    await _teamRepository.DeletePlayer(player);
        //    await _teamRepository.SaveAsync(team);
        //}

        public async Task<Product> GetProductByIdAsync(long id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
