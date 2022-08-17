using MVCFramework.MVCViewEngine;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework
{
    public abstract class Controller
    {
        private IViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new ViewEngine();
        }

        public IHttpRequest? Request { get; set; }
        public IHttpResponse View(object? viewModel=null,[CallerMemberName]string path = null!)
        {

            string content = File.ReadAllText("Views/" +this.GetType().Name.Replace("Controller",string.Empty)+ "/" + path + ".cshtml");
            var view = viewEngine.GenerateView(content, viewModel);
            return new HtmlResult(view, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);
        }

        public IHttpResponse Redirect(string path)
        {

            return new RedirectResult(path);
        }
    }
}
