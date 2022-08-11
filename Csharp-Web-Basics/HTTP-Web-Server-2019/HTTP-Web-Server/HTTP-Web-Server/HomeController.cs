using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);
        }
    }
}
