using System.Collections.Generic;
using System.Threading.Tasks;
using innoStarkAssignment.Core;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Core.Services;

namespace innoStarkAssignment.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category newCategory)
        {
            await _unitOfWork.Categories
                .AddAsync(newCategory);

            return newCategory;
        }

        public async Task DeleteCategory(Category Category)
        {
            _unitOfWork.Categories.Remove(Category);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task UpdateCategory(Category CategoryToBeUpdated, Category Category)
        {
            CategoryToBeUpdated.Name = Category.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
