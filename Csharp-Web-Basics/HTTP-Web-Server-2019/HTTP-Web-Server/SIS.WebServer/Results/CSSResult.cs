using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.WebServer.Results
{
    public class CSSResult : HttpResponse
    {
        public CSSResult(string content, HttpResponseStatusCode statusCode) : base(content, statusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/css"));

        }
    }
}
