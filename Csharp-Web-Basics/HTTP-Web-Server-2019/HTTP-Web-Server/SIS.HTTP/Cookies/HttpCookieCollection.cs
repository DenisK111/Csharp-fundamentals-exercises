using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        string HttpCookieStringSeparator = "\r\n";
        private Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            cookies = new Dictionary<string, HttpCookie>();
        }
        public void AddCookie(HttpCookie cookie)
        {
            cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            return cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            if (cookies.ContainsKey(key))
            {
                return cookies[key];
            }

            return null!;
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (var kvp in cookies)
            {
                yield return kvp.Value;
            }
        }

        public bool HasCookies()
        {
            return cookies.Any();
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

        public override string ToString()
        {
            return String.Join(HttpCookieStringSeparator, this.cookies.Values);
        }
    }
}
