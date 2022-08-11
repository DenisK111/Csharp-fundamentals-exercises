using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HTTP.Headers.HttpHeader("Location", location));
        }
    }
}
