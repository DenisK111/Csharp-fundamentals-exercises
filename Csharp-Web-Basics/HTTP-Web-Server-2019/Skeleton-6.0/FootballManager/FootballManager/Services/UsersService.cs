using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly FootballManagerDbContext context;

        public UsersService(FootballManagerDbContext context)
        {
            this.context = context;
        }
        public void AddRegistration(InputRegisterModel model)
        {
            this.context.Add(new User
            {
                Username = model.Username,
                Password = GetSHA512Password(model.Password),
                Email = model.Email
            });
            context.SaveChanges();
        }

        public bool AuthenticateLogin(string username, string password)
        {
            throw new NotImplementedException();
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
