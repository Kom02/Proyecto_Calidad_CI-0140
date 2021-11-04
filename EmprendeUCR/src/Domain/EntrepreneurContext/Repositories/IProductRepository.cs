using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;

namespace EmprendeUCR.Domain.EntrepreneurContext.Repositories
{
    public interface IProductRepository
    {
        Task SaveAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllByCategoryAsync(int categoryId);
        Task<Product?> GetByIdAsync(long id);

        //Task DeletePlayer(Player player);
    }
}
