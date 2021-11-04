using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Categories.Entities;
namespace EmprendeUCR.Application.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task ChangeTitle(Category category);
        Task ChangeDescription(Category category);
        Task ChangeParentId(Category category);
    }
}