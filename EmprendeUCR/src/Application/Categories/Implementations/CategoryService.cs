using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Categories.Entities;
using EmprendeUCR.Domain.Categories.Repositories;
namespace EmprendeUCR.Application.Categories.Implementations
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository .GetAllAsync();
        }

        public Task ChangeTitle(Category category)
        {
            throw new System.NotImplementedException();
        }
        public Task ChangeDescription(Category category)
        {
            throw new System.NotImplementedException();
        }
        public Task ChangeParentId(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
        