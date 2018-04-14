using StackAlmostflow.Database.Common.Base;
using StackAlmostflow.Database.Common.Interfaces;
using StackAlmostflow.Entity.Interfaces;

namespace StackAlmostflow.Database.Concrete
{
    public abstract class StackAlmostflowRepositoryBase<TEntity>
        : RepositoryBase<TEntity, StackAlmostflowDbContext>
        where TEntity : class, IEntity, new()
    {
        protected StackAlmostflowRepositoryBase(IDbContextFactory<StackAlmostflowDbContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
