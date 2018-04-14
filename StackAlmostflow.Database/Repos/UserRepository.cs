using StackAlmostflow.Database.Common.Base;
using StackAlmostflow.Database.Concrete;
using StackAlmostflow.Database.Repos.Interfaces;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Database.Concrete.Interfaces;
using StackAlmostflow.Utils;

namespace StackAlmostflow.Database.Repos
{
    [NinjectDependency(typeof(IUserRepository), NinjectDependencyScope.Request)]
    public class UserRepository : RepositoryBase<User, StackAlmostflowDbContext>, IUserRepository
    {
        public UserRepository(IStackAlmostflowDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
