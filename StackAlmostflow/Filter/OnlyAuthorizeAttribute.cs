using StackAlmostflow.Controllers.Api;
using StackAlmostflow.Ninject;
using StackAlmostflow.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace StackAlmostflow.Filter
{
    public class OnlyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var userService = GlobalDependencyResolver.GetService<IUserService>();
            
            var token = actionContext.Request.Headers.GetCookies("AUTH").FirstOrDefault();

            if (token == null)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized) { Content = new StringContent("Authorization required for this request") };
                return;
            }

            var user = userService.CheckToken(token.Cookies.First().Value).Result;
            if (user == null)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized) { Content = new StringContent("Invalid security token") };
                return;
            }

            ((BaseApiController)actionContext.ControllerContext.Controller).CurrentUser = user;
        }
    }
}