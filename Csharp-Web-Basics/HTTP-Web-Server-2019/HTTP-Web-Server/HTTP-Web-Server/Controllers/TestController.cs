using MVCFramework;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Controllers
{
    public class TestController : Controller
    {
        public IHttpResponse Result(IHttpRequest request)
        {
            string content = "<h1>Result</h1>";

            return new HtmlResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);
        }
    }
}
