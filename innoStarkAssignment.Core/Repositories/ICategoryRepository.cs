using innoStarkAssignment.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace innoStarkAssignment.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithBlogAsync();
        Task<Category> GetWithBlogByIdAsync(int id);
    }
}
