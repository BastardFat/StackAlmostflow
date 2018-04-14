using StackAlmostflow.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Entity.Models
{
    public class Answer : IEntity
    {
        public virtual long Id { get; set; }
        public virtual long UserId { get; set; }
        public virtual long QuestionId { get; set; }

        public virtual string Text { get; set; }

        public virtual User User { get; set; }
        public virtual Question Question { get; set; }

    }
}
