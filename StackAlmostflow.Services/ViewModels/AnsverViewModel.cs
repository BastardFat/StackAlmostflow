using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.ViewModels
{
    public class AnswerViewModel
    {
        public virtual long Id { get; set; }
        public virtual long UserId { get; set; }
        public virtual long QuestionId { get; set; }

        public virtual string Text { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}
