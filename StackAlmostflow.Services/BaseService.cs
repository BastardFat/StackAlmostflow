using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services
{
    public abstract class BaseService
    {
    }


    [Serializable]
    public class WebsiteException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public WebsiteException(string message) : this(HttpStatusCode.InternalServerError, message) { }

        public WebsiteException(HttpStatusCode statusCode) : this(statusCode, null) { }

        public WebsiteException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public WebsiteException(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }





        protected WebsiteException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
