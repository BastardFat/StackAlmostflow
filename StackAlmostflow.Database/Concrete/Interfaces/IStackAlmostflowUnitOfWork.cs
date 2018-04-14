using StackAlmostflow.Database.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Database.Concrete.Interfaces
{
    public interface IStackAlmostflowUnitOfWork
    : IUnitOfWork<StackAlmostflowDbContext>
    {
    }
}
