using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Categories.Entities;

namespace EmprendeUCR.Domain.Categories.Repositories
{
    public interface ICategoryRepository
    {
        Task SaveAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}

