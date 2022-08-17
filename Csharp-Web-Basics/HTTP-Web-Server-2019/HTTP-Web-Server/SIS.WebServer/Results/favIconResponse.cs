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
    public class favIconResponse : HttpResponse
    {
        public favIconResponse(string content, HttpResponseStatusCode statusCode) : base(content,statusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "image/x-icon"));
           
        }
    }
}
