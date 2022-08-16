using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.WebServer.Results;

namespace HTTP_Web_Server.Controllers
{
    public class StaticFilesController
    {
        public IHttpResponse Favicon()
        {
            var content = File.ReadAllBytes("favicon.ico");

            return new ImageResult(content.ToString()!,SIS.HTTP.Enums.HttpResponseStatusCode.Ok); 

        }

        public  IHttpResponse Reset()
        {
            var content = File.ReadAllText("wwwroot/css/reset-css.css");

            return new CSSResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

        }

        public IHttpResponse BootstrapCss()
        {
            var content =  File.ReadAllText("wwwroot/css/bootstrap.min.css");

            return new CSSResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

        }
        public IHttpResponse Style()
        {
            var content =  File.ReadAllText("wwwroot/css/style.css");

            return new CSSResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

        }
        public IHttpResponse JQuery()
        {
            var content = File.ReadAllText("wwwroot/js/jquery-3.4.1.min.js");

            return new JsResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

        }

        public IHttpResponse Popper()
        {
            var content =  File.ReadAllText("wwwroot/js/popper.min.js");

            return new JsResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

        }

        public IHttpResponse BootstrapJs()
        {
            var content =  File.ReadAllText("wwwroot/js/bootstrap.min.js");

            return new JsResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

        }



        /*<link rel="stylesheet" type="text/css" href="/wwwroot/css/reset-css.css">
         <link rel="stylesheet" type="text/css" href="/wwwroot/css/bootstrap.min.css">
         <link rel="stylesheet" type="text/css" href="/wwwroot/css/style.css">
         <script src="/wwwroot/js/jquery-3.4.1.min.js"></script>
         <script src="/wwwroot/js/popper.min.js"></script>
         <script src="/wwwroot/js/bootstrap.min.js"></script>*/
    }
}
