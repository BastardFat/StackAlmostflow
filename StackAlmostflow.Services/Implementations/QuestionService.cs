using AutoMapper;
using AutoMapper.QueryableExtensions;
using BotMagic.Utils;
using StackAlmostflow.Database.Concrete.Interfaces;
using StackAlmostflow.Database.Repos.Interfaces;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Services.Interfaces;
using StackAlmostflow.Services.ViewModels;
using StackAlmostflow.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.Implementations
{
    [NinjectDependency(typeof(IQuestionService), NinjectDependencyScope.Request)]
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IStackAlmostflowUnitOfWork _uow;
        private readonly IMapper _mapper;

        public QuestionService(IUserRepository userRepository,
            IQuestionRepository questionRepository,
            IAnswerRepository answerRepository,
            IMapper mapper,
            IStackAlmostflowUnitOfWork uow)
        {
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
            _uow = uow;
        }



        public async Task<QuestionViewModel> AskQuestion(QuestionViewModel model, long userId)
        {
            var entity = _mapper.Map<Question>(model);
            entity.UserId = userId;
            entity = _questionRepository.Add(entity);
            await _uow.CommitAsync();
            var result = _mapper.Map<QuestionViewModel>(entity);
            return result;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetTopQuestions(int maxCount, long userId)
        {
            return await _questionRepository
                .Query()
                .Where(x => x.UserId != userId)
                .OrderByDescending(x => x.Score)
                .Take(maxCount)
                .ProjectTo<QuestionViewModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<AnswerViewModel> AnswerQuestion(long questionId, string answer, long userId)
        {
            var entity = _answerRepository.Add(new Answer
            {
                Text = answer,
                QuestionId = questionId,
                UserId = userId
            });
            await _uow.CommitAsync();
            var result = _mapper.Map<AnswerViewModel>(entity);
            return result;
        }


    }
}
