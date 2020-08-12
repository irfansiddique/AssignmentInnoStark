using System.Collections.Generic;
using System.Threading.Tasks;
using innoStarkAssignment.Core.Model;

namespace innoStarkAssignment.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> CreateCategory(Category newCategory);
        Task UpdateCategory(Category CategoryToBeUpdated, Category Category);
        Task DeleteCategory(Category Category);
    }
}
