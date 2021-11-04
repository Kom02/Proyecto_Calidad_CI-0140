using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.Entrepreneurs
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(long id);
        //Task AddPlayerToTeamRosterAsync(Team team, Player player);
        //Task DeletePlayerAndRemoveFromTeamRosterAsync(Team team, Player player);        
    }
}
