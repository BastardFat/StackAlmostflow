using Newtonsoft.Json;
using StackAlmostflow.Database.Repos.Interfaces;
using StackAlmostflow.Entity.Models;
using StackAlmostflow.Filter;
using StackAlmostflow.Services.Interfaces;
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
    [RoutePrefix("api/user")]
    public class UserController: BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("login")]
        public async Task<string> Login(string login, string pass)
        {
            var user = await _userService.Login(login, pass);
            var token = await _userService.GenerateToken(user);
            HttpContext.Current.Response.Cookies.Set(new HttpCookie("AUTH", HttpContext.Current.Server.UrlEncode(token)) { Expires = DateTime.UtcNow + TimeSpan.FromDays(5) });
            return token;
        }

        [OnlyAuthorize]
        [HttpGet]
        [Route("test")]
        public async Task<string> Test()
        {
            return $"Hello, {CurrentUser.Login}!";
        }


    }
}