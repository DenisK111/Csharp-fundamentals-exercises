using MVCFramework;
using MVCFramework.Attributes;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet("/login")]
        public IHttpResponse Login()
        {
            return View();
        }
        [HttpGet("/register")]
        public IHttpResponse Register()
        {
            return View();
        }
    }
}
