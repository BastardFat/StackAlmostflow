using System.Data.Entity;

namespace StackAlmostflow.Database.Common.Interfaces
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
