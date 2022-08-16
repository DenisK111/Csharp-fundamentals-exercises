using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP.Headers;

namespace SIS.WebServer.Results
{
    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content,HttpResponseStatusCode statusCode) : base(content, statusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text-html charset=utf-8"));
            var layout = File.ReadAllText("Views/Layout.cshtml");
            this.Content = Encoding.UTF8.GetBytes(content);
            this.Headers.AddHeader(new HttpHeader("Content-Length", $"{this.Content.Length}"));
        }
    }
}
