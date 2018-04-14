using AutoMapper;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.Configurations
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration CreateMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>()
                    .ReverseMap();

                cfg.CreateMap<Answer, AnswerViewModel>()
                    .ReverseMap();

                cfg.CreateMap<Question, QuestionViewModel>()
                    .ReverseMap();

            });
        }
    }
}
