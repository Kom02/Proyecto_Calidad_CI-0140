using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.EntrepreneurContext.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.Entrepreneurs.Repositories
{
    internal class ProductServiceRepository : IProductServiceRepository
    {
        private readonly EntrepreneursDbContext _dbContext; 
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProductServiceRepository(EntrepreneursDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<List<Product_Service>> GetAllAsync()
        {
            return await _dbContext.ProductServices.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product_Service> GetByIdAsync(long id)
        {
            return await _dbContext.ProductServices.FirstOrDefaultAsync(t => t.Code_ID == id);
        }

        public async Task SaveAsync(Product_Service product_service)
        {
            _dbContext.Update(product_service);

            await _dbContext.SaveEntitiesAsync();
        }
    }
}
