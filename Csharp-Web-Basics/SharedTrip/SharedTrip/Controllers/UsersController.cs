using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Services;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
private readonly IUserService service;
        public UsersController(Request request, IUserService service) : base(request)
        {
            this.service = service;
        }

        public Response Login()
        {
            if (this.User.IsAuthenticated)
                return this.Redirect("/");
            return this.View(new { IsAuthenticated = false });
        }

        public Response Register()
        {
            if (this.User.IsAuthenticated)
                return this.Redirect("/");
            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(InputRegisterModel model)
        {
            if (this.User.IsAuthenticated)
                return this.Redirect("/");


            if (model.UserName.Length < 5 || model.UserName.Length > 20)
            {
                return this.Register();
            }
                      
            
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Register();
            }

            // Added Email Validation
            if (!(new EmailAddressAttribute().IsValid(model.Email)))
            {
               return this.Register();
            }
            //Added check if user is already registered
            if (service.CheckIfUserExists(model.UserName))
            {
                return this.Register();
            }
            service.AddRegistration(model);

            return this.Redirect("/Users/Login");

        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {

            if (this.User.IsAuthenticated)
                return this.Redirect("/");

            if (service.AuthenticateLogin(model.Username, model.Password))
            {
                this.SignIn(model.Username);
            }

            else
            {
               return this.Login();
            }

            return this.Redirect("/");

        }

        public Response Logout()
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");

            SignOut();

            return Redirect("/");
        }
    }
}
