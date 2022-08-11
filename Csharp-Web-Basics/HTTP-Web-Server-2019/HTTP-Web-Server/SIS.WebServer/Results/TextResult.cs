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
    public class TextResult : HttpResponse
    {
        public TextResult(byte[] content,HttpResponseStatusCode statusCode, string contentType = "text/plain charset=utf-8") : base(statusCode)
        {
            this.Content = content;
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
        }

        public TextResult(string content, HttpResponseStatusCode statusCode, string contentType = "text/plain charset=utf-8") : base(statusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        
    }
}
