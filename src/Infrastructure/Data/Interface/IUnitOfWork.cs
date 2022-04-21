using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
