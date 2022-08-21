using HTTP_Web_Server.Data;
using HTTP_Web_Server.Data.Models;
using HTTP_Web_Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVCFramework;
using MVCFramework.Attributes;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IHttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return Error("You are already logged in!");
            }
            return View();
        }
        [HttpPost("/login")]
        public IHttpResponse DoLogin(string username, string password)
        {
            var result = context.Users.FirstOrDefault(x =>
           x.UserName == username
           && x.Password == GetSHA512Password(password)
                       );
            if (result == null)
            {
                return Error("Invalid Username or Password");
            }


            this.SignIn(result.UserName,result.Role);
            return Redirect("home/index");
        }

        [HttpPost("/register")]
        public IHttpResponse DoRegister(string username, string password, string confirmpassword, string email)
        {

            if (password != confirmpassword)
            {
                return Error("Passwords do not match");
            }

            if (context.Users.Any(x=>x.UserName == username))
            {
                return Error("Username already exists");
            }


            this.context.Users.Add(new User
            {
                UserName = username,
                Password = GetSHA512Password(password),
                Email = email,
                Role = IdentityRole.User                

            });
            context.SaveChanges();

            return Redirect("users/login");
        }

        public IHttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return Error("You are already logged in!");
            }

         

            return View();
        }

        public IHttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return Error("You are not logged in!");
            }
            this.SignOut();
            return this.Redirect("../home/Index");
        }

        public IHttpResponse Profile()
        {
            if (!this.IsUserSignedIn())
            {
                return Error("User not signed in!");
            }
                 

            var result = context.Users
                .Include(r=>r.Receipts)
                .ThenInclude(o=>o.Orders)
                .ThenInclude(p=>p.Product)
                .First(x => x.UserName == this.Request!.Session.GetValue(UserIdSessionName)!.Value.userId)
                .Receipts.Select(x => new ProfileViewModel
                {
                    Id = x.Id,
                    Total = x.Orders.Sum(p => p.Product.Price * p.Quantity).ToString("f2",CultureInfo.InvariantCulture),
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Cashier = x.Cashier.UserName

                })
                .ToList();
            
            return View(result);
        }

        private static string GetSHA512Password(string password)
        {


            string hash = "";
            SHA512 alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(password));
            hash = Encoding.UTF8.GetString(result);
            return hash;

        }

        
    }
}
