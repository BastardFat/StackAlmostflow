using StackAlmostflow.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Entity.Models
{
    public class Question : IEntity
    {
        public virtual long Id { get; set; }

        public virtual long UserId { get; set; }
        public virtual string Body { get; set; }
        public virtual string Title { get; set; }
        public virtual int Score { get; set; }

        public virtual long? AcceptedAnsverId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
