using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.EntrepreneurContext.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.Entrepreneurs.Repositories
{
    internal class ProductPhotosRepository : IProductPhotosRepository
    {
        private readonly EntrepreneursDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProductPhotosRepository(EntrepreneursDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<List<ProductPhotos>> GetAllByProductIDAsync(long id)
        {
            return await _dbContext.ProductPhotos.Where(p=> p.Code_ID == id).ToListAsync();
        }

        public async Task<List<ProductPhotos>> GetAllAsync()
        {
            return await _dbContext.ProductPhotos.ToListAsync();

        }

        public async Task<ProductPhotos?> GetByIdAsync(long id)
        {
            return await _dbContext.ProductPhotos
                //.Include(t => t.Photos)
                .FirstOrDefaultAsync(t => t.Product_Photos_ID == id);
        }

        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(ProductPhotos ProductPhotos)
        {
            _dbContext.Update(ProductPhotos);

            await _dbContext.SaveEntitiesAsync();
        }
    }
}
