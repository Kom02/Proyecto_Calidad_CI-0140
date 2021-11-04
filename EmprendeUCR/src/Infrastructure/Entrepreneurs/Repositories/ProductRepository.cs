using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Infrastructure.Entrepreneurs;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Domain.EntrepreneurContext.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly EntrepreneursDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProductRepository(EntrepreneursDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.Include(p => p.Photos).ToListAsync();

        }
        public async Task<List<Product>> GetAllByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
                //.Where(p => p.Category.Id == categoryId)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _dbContext.Products
                //.Include(t => t.Photos)
                .FirstOrDefaultAsync(t => t.Code_ID == id);
        }

        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(Product product)
        {
            _dbContext.Update(product);

            await _dbContext.SaveEntitiesAsync();
        }

        //public Task DeletePlayer(Player player)
        //{
        //    _dbContext.Remove(player);

        //    return Task.CompletedTask;
        //}
    }
}
