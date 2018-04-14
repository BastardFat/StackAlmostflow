using StackAlmostflow.Database.Common.Base;
using StackAlmostflow.Database.Concrete;
using StackAlmostflow.Database.Repos.Interfaces;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Database.Concrete.Interfaces;
using StackAlmostflow.Utils;

namespace StackAlmostflow.Database.Repos
{
    [NinjectDependency(typeof(IAnswerRepository), NinjectDependencyScope.Request)]
    public class AnswerRepository : RepositoryBase<Answer, StackAlmostflowDbContext>, IAnswerRepository
    {
        public AnswerRepository(IStackAlmostflowDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
