using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
            this.ParseRequest(requestString);
        }



        public string Path { get; private set; } = null!;

        public string Url { get; private set; } = null!;

        public Dictionary<string, object> FormData { get; } = null!;

        public Dictionary<string, object> QueryData { get; } = null!;

        public IHttpHeaderCollection Headers { get; } = null!;

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection CookieCollection { get; }
        public IHttpSession Session { get; set; } = null!;

        private void ParseQueryParameters()
        {
            var query = this.Url.Split("?", StringSplitOptions.RemoveEmptyEntries);

            if (query.Length == 1)
            {
                return;
            }

            var queryString = query[1];

            MapQueryString(QueryData, queryString);


        }

        private void MapQueryString(Dictionary<string, object> queryData, string queryString)
        {
            var parameters = queryString.Split("&");

            foreach (var parameter in parameters)
            {
                var split = parameter.Split("=");

                if (split.Length != 2)
                {
                    throw new BadRequestException();
                }

                var key = split[0];
                var value = split[1];

                queryData[key] = new
                {
                    Key = key,
                    Value = value
                };
            }

        }

        private void ParseFormDate(string bodyString)
        {
            if (string.IsNullOrWhiteSpace(bodyString))
            {
                return;
            }

            MapQueryString(this.FormData, bodyString);
        }
        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath(requestLine);

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());

            this.ParseCookies();
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseRequestParameters(string bodyString)
        {
            ParseQueryParameters();
            ParseFormDate(bodyString);
        }

        private void ParseCookies()
        {

            if (!Headers.ContainsHeader("Cookie"))
                return;

            var value = Headers.GetHeader("Cookie").Value;


            var cookies = value.Split("; ");

            foreach (var cookie in cookies)
            {
                var kvp = cookie.Split("=",2);

                CookieCollection.AddCookie(new HttpCookie(kvp[0], kvp[1]));
            }


        }

        private void ParseHeaders(string[] strings)
        {
            foreach (var header in strings)
            {
                var split = header.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (split.Length != 2)
                {
                    continue;
                }

                var key = split[0];
                var value = split[1];

                Headers.AddHeader(new HttpHeader(key, value));
            }

            if (!Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseRequestPath(string[] requestLine)
        {
            this.Path = this.Url.Split("?")[0];
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            this.RequestMethod = Enum.Parse<HttpRequestMethod>(requestLine[0].Capitalize());
        }

        private bool IsValidRequestLine(string[] requestLine) =>
             requestLine.Length == 3 && requestLine[2] == "HTTP/1.1";



    }
}
