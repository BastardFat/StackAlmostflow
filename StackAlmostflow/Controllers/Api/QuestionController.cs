using Newtonsoft.Json;
using StackAlmostflow.Database.Repos.Interfaces;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Filter;
using StackAlmostflow.Models.Requests;
using StackAlmostflow.Services.Interfaces;
using StackAlmostflow.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace StackAlmostflow.Controllers.Api
{
    [OnlyAuthorize]
    [RoutePrefix("api/question")]
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        [Route("ask")]
        public async Task<QuestionViewModel> AskQuestion(QuestionViewModel model)
        {
            return await _questionService.AskQuestion(model, CurrentUser.Id);
        }


        [HttpPost]
        [Route("answer/{questionId}")]
        public async Task<AnswerViewModel> AnswerQuestion(AnswerRequest request, long questionId)
        {
            return await _questionService.AnswerQuestion(questionId, request.Text, CurrentUser.Id);
        }

        [HttpGet]
        [Route("get/score")]
        public async Task<IEnumerable<QuestionViewModel>> GetQuestions()
        {
            return await _questionService.GetTopQuestions(20, CurrentUser.Id);
        }
    }
}