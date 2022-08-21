using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private  static Dictionary<string, (string? userId, int userRole)?> session = null!;

        public HttpSession(string id)
        {
            session = new Dictionary<string, (string? userId, int userRole)?>();
            this.Id = id;
        }

        public string Id { get; }

        public (string? userId, int userRole)? GetValue(string name)
        {
            if (!session.ContainsKey(name))
                return null!;

            return session[name];
        }

        public bool ContainsParameter(string name)
        {
            return session.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter,int role)
        {
            
            session[name] = ((string?)parameter, role);
        }

        public void ClearParameters()
        {
            session.Clear();
        }

        public void SetParameterToNull(string name)
        {
            session[name] = null!;

        }

        
    }
}
