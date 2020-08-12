using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Core.Repositories;

namespace innoStarkAssignment.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(InnoStarkDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Category>> GetAllWithBlogAsync()
        {
            return await innoStarkDbContext.Categories
                .Include(a => a.Blogs)
                .ToListAsync();
        }

        public Task<Category> GetWithBlogByIdAsync(int id)
        {
            return innoStarkDbContext.Categories
                .Include(a => a.Blogs)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private InnoStarkDbContext innoStarkDbContext
        {
            get { return Context as InnoStarkDbContext; }
        }
    }
}
