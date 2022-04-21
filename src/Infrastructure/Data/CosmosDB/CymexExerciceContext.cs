using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data.CosmosDB
{
    public class CymexExerciceContext : DbContext
    {
        public CymexExerciceContext(DbContextOptions<CymexExerciceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }

        public static async Task CheckAndSeedDatabaseAsync(DbContextOptions<CymexExerciceContext> options)
        {
            //
        }
    }
}
