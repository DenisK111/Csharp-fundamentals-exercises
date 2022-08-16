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
    public class HomeController : Controller
    {
        public IHttpResponse Index()
        {
            return View();
        }

        public IHttpResponse Privacy()
        {
            return View();
        }
    }
}
