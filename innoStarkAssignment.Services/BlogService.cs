using System.Collections.Generic;
using System.Threading.Tasks;
using innoStarkAssignment.Core;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Core.Services;

namespace innoStarkAssignment.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Blog> CreateBlog(Blog newBlog)
        {
            await _unitOfWork.Blogs.AddAsync(newBlog);
            await _unitOfWork.CommitAsync();
            return newBlog;
        }

        public async Task DeleteBlog(Blog Blog)
        {
            _unitOfWork.Blogs.Remove(Blog);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategory()
        {
            return await _unitOfWork.Blogs
                .GetAllWithCategoryAsync();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _unitOfWork.Blogs
                .GetWithCategoryByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetBlogsByCategoryId(int CategoryId)
        {
            return await _unitOfWork.Blogs
                .GetAllWithCategoryByCategoryIdAsync(CategoryId);
        }

        public async Task UpdateBlog(Blog BlogToBeUpdated, Blog Blog)
        {
            BlogToBeUpdated.Name = Blog.Name;
            BlogToBeUpdated.CategoryId = Blog.CategoryId;

            await _unitOfWork.CommitAsync();
        }
    }
}
