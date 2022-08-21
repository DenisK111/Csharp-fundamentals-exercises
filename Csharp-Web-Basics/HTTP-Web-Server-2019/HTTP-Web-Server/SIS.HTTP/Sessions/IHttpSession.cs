using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Sessions
{
    public interface IHttpSession
    {
        string Id { get; }

        (string? userId, int userRole)? GetValue(string name);

        bool ContainsParameter(string name);

        void AddParameter(string name, object parameter,int role);

        void ClearParameters();

        void SetParameterToNull(string UserIdSessionName);

    }
}
