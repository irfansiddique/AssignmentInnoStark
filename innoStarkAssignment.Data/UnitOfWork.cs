using System.Threading.Tasks;
using innoStarkAssignment.Core;
using innoStarkAssignment.Core.Repositories;
using innoStarkAssignment.Data.Repositories;

namespace innoStarkAssignment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InnoStarkDbContext _context;
        private BlogRepository _BlogRepository;
        private CategoryRepository _CategoryRepository;

        public UnitOfWork(InnoStarkDbContext context)
        {
            this._context = context;
        }

        public IBlogRepository Blogs => _BlogRepository = _BlogRepository ?? new BlogRepository(_context);

        public ICategoryRepository Categories => _CategoryRepository = _CategoryRepository ?? new CategoryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
