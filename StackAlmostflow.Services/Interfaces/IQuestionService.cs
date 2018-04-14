using StackAlmostflow.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<AnswerViewModel> AnswerQuestion(long questionId, string answer, long userId);
        Task<QuestionViewModel> AskQuestion(QuestionViewModel model, long userId);
        Task<IEnumerable<QuestionViewModel>> GetTopQuestions(int maxCount, long userId);
    }
}
