using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Entity.Interfaces
{
    public interface IObservableEntity : IEntity
    {
        DateTime UpdatedAt { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
