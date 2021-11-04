using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Categories.Entities;
using EmprendeUCR.Domain.Categories.Repositories;
using EmprendeUCR.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.Categories.Repositories
{
    internal class CategoriesRepository : ICategoryRepository
    {
        private readonly CategoriesDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public CategoriesRepository(CategoriesDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories
            .Select(c => new Category(c.Title, c.Description, c.ParentId))
            .ToListAsync();
        }   
        public async Task<Category> GetByIdAsync(int Id)
        {
            return await _dbContext.Categories
            .FirstOrDefaultAsync(t => t.Id == Id);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(Category categories)
        {
            _dbContext.Update(categories);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}


