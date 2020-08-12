using System;
using System.Collections.Generic;
using innoStarkAssignment.Core.Model;
using System.Threading.Tasks;

namespace innoStarkAssignment.Core.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetAllWithCategoryAsync();
        Task<Blog> GetWithCategoryByIdAsync(int id);
        Task<IEnumerable<Blog>> GetAllWithCategoryByCategoryIdAsync(int categoryId);
    }
}
