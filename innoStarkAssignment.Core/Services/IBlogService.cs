using System.Collections.Generic;
using System.Threading.Tasks;
using innoStarkAssignment.Core.Model;

namespace innoStarkAssignment.Core.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllWithCategory();
        Task<Blog> GetBlogById(int id);
        Task<IEnumerable<Blog>> GetBlogsByCategoryId(int CategoryId);
        Task<Blog> CreateBlog(Blog newBlog);
        Task UpdateBlog(Blog BlogToBeUpdated, Blog Blog);
        Task DeleteBlog(Blog Blog);
    }
}
