using System.Web.Http;
using StackAlmostflow.Services.ViewModels;

namespace StackAlmostflow.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        public UserViewModel CurrentUser { get; set; }
    }
}