using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private  static Dictionary<string, object> session = null!;

        public HttpSession(string id)
        {
            session = new Dictionary<string, object>();
            this.Id = id;
        }

        public string Id { get; }

        public object GetParameter(string name)
        {
            if (!session.ContainsKey(name))
                return null!;

            return session[name];
        }

        public bool ContainsParameter(string name)
        {
            return session.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter)
        {
            session[name] = parameter;
        }

        public void ClearParameters()
        {
            session.Clear();
        }
    }
}
