using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IUsersService
    {
        bool AuthenticateLogin(string username, string password);

        void AddRegistration(InputRegisterModel model);

    }
}
