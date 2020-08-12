using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Core.Repositories;

namespace innoStarkAssignment.Data.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(InnoStarkDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryAsync()
        {
            return await innoStarkDbContext.Blogs
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<Blog> GetWithCategoryByIdAsync(int id)
        {
            return await innoStarkDbContext.Blogs
                .Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryByCategoryIdAsync(int CategoryId)
        {
            return await innoStarkDbContext.Blogs
                .Include(m => m.Category)
                .Where(m => m.CategoryId == CategoryId)
                .ToListAsync();
        }

        private InnoStarkDbContext innoStarkDbContext
        {
            get { return Context as InnoStarkDbContext; }
        }
    }
}
