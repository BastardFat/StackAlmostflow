using AutoMapper;
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
    [NinjectDependency(typeof(IUserService), NinjectDependencyScope.Request)]
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStackAlmostflowUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly HmacSerializer<UserViewModel> _hmacSerializer;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IStackAlmostflowUnitOfWork uow)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;

            _hmacSerializer = new HmacSerializer<UserViewModel>("Penis");
        }


        public async Task<UserViewModel> Register(string login, string password)
        {
            var loginExists =await _userRepository.Query().Where(x => x.Login == login).AnyAsync();

            if (loginExists)
                throw new WebsiteException(HttpStatusCode.Conflict, "User with this name already exist");

            var entity = _userRepository.Add(new User
            {
                Login = login,
                Password = password
            });

            await _uow.CommitAsync();

            return _mapper.Map<UserViewModel>(entity);
        }

        public async Task<UserViewModel> Login(string login, string password)
        {
            var user = await _userRepository
                .Query()
                .Where(x => x.Login == login && x.Password == password)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new WebsiteException(HttpStatusCode.Unauthorized, "Invalid login or password");

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<string> GenerateToken(UserViewModel user)
        {
            return _hmacSerializer.Serialize(user);
        }

        public async Task<UserViewModel> CheckToken(string token)
        {
            try
            {
                return _hmacSerializer.Deserialize(token);
            }
            catch (HmacDeserializationException)
            {
                return null;
            }

        }

    }
}
