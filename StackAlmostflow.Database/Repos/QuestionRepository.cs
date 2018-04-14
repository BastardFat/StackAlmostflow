using StackAlmostflow.Database.Common.Base;
using StackAlmostflow.Database.Concrete;
using StackAlmostflow.Database.Repos.Interfaces;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Database.Concrete.Interfaces;
using StackAlmostflow.Utils;

namespace StackAlmostflow.Database.Repos
{
    [NinjectDependency(typeof(IQuestionRepository), NinjectDependencyScope.Request)]
    public class QuestionRepository : RepositoryBase<Question, StackAlmostflowDbContext>, IQuestionRepository
    {
        public QuestionRepository(IStackAlmostflowDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
