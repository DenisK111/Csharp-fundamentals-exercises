using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddRegistration(InputRegisterModel model)
        {
            this.context.Add(new User
            {
                Username = model.UserName,
                Password = GetSHA512Password(model.Password),
                Email = model.Email
            });
            context.SaveChanges();
        }

        public bool AuthenticateLogin(string username, string password) => context.Users
            .Any(x => x.Username == username && GetSHA512Password(password) == x.Password);

        private static string GetSHA512Password(string password)
        {


            string hash = "";
            SHA512 alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(password));
            hash = Encoding.UTF8.GetString(result);
            return hash;

        }

        public bool CheckIfUserExists(string username)
        {
            return this.context.Users.Any(x => x.Username == username);
        }
    }
}
