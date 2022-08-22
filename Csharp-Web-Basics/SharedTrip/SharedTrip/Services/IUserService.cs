using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        bool AuthenticateLogin(string username, string password);

        void AddRegistration(InputRegisterModel model);

        bool CheckIfUserExists(string username);
    }
}
