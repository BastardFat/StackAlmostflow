using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.ViewModels
{
    public class QuestionViewModel
    {
        public virtual long Id { get; set; }

        public virtual long UserId { get; set; }
        public virtual string Body { get; set; }
        public virtual string Title { get; set; }
        public virtual int Score { get; set; }

        public virtual long? AcceptedAnsverId { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}
