using StackAlmostflow.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> Login(string login, string password);
        Task<UserViewModel> Register(string login, string password);
        Task<string> GenerateToken(UserViewModel user);
        Task<UserViewModel> CheckToken(string token);
    }
}
