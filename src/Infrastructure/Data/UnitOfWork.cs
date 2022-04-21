using Infrastructure.Data.CosmosDB;
using Infrastructure.Data.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CymexExerciceContext _context;

        public UnitOfWork(CymexExerciceContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
