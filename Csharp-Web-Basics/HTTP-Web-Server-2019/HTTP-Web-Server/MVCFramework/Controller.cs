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
        private const string UserIdSessionName = "UserId";
        public Controller()
        {
            this.viewEngine = new ViewEngine();
        }

        public IHttpRequest? Request { get; set; }
        protected IHttpResponse View(object? viewModel=null,[CallerMemberName]string path = null!)
        {

            string content = File.ReadAllText("Views/" +this.GetType().Name.Replace("Controller",string.Empty)+ "/" + path + ".cshtml");
            var view = viewEngine.GenerateView(content, viewModel);
            return new HtmlResult(view, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse Redirect(string path)
        {

            return new RedirectResult(path);
        }

        protected IHttpResponse Error(string errorText)
        {

            string content = File.ReadAllText("Views/Error.cshtml");
            var view = viewEngine.GenerateView(content, errorText,(string?)this.Request!.Session.GetValue(UserIdSessionName));
            return new HtmlResult(view, SIS.HTTP.Enums.HttpResponseStatusCode.InternalServerError);
        }

        protected void SignIn(string userId)
        {
         

            this.Request!.Session.AddParameter(UserIdSessionName, userId);
        }

        protected void SignOut()
        {
            this.Request!.Session.ClearParameters();
        }

        protected bool IsUserSignedIn()
        {
            return this.Request!.Session.ContainsParameter(UserIdSessionName);
        }

        protected object GetUserId()
        {
            return this.Request!.Session.GetValue(UserIdSessionName);

        }

        private string PutViewInLayout(string viewContent,object? viewModel = null,string? user = null)
        {

            var layout = File.ReadAllText("/Views/Layout.cshtml");
            layout = layout.Replace("{{RenderBody}}", "View_goes_here");
            layout = this.viewEngine.GenerateView(layout, viewModel, user);
            var responseHtml = layout.Replace("View_goes_here", viewContent);
            return responseHtml;
        }
    }
}
