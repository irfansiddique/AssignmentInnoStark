using System;
using innoStarkAssignment.Core.Repositories;
using System.Threading.Tasks;

namespace innoStarkAssignment.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        ICategoryRepository Categories { get; }
        Task<int> CommitAsync();
    }
}
