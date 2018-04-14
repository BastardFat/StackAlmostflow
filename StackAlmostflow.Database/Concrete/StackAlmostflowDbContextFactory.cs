using StackAlmostflow.Database.Common.Base;
using StackAlmostflow.Database.Concrete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Database.Concrete
{
    public class StackAlmostflowDbContextFactory
        : DbContextFactoryBase<StackAlmostflowDbContext>, IStackAlmostflowDbContextFactory
    {
    }
}
