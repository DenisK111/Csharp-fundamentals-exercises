using SIS.HTTP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {

        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header )
        {
            headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            return headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            return headers.ContainsKey(key) ? headers[key] : null!;
        }

        public override string ToString()
        {
            return String.Join(GlobalConstants.HttpNewLine, headers.Values);
        }

    }
}
