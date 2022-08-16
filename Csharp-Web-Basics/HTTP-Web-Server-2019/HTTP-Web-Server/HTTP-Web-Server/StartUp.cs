using HTTP_Web_Server.Controllers;
using MVCFramework;
using SIS.HTTP.Enums;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server
{
    public class StartUp : MVCApplication
    {
        public  override IServerRoutingTable ConfigureRoutingTable()
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(SIS.HTTP.Enums.HttpRequestMethod.Get, "/home/index",
                request => new HomeController().Index());
            serverRoutingTable.Add(SIS.HTTP.Enums.HttpRequestMethod.Get, "/",
               request => new HomeController().Index());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/test/result",
                request => new TestController().Result(request));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/home/privacy",
                request => new HomeController().Privacy());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/favicon.ico",
                request => new StaticFilesController().Favicon());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/css/reset-css.css",
              request=> new StaticFilesController().Reset());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/css/bootstrap.min.css",
               request => new StaticFilesController().BootstrapCss());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/css/style.css",
               request => new StaticFilesController().Style());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/js/jquery-3.4.1.min.js",
               request => new StaticFilesController().JQuery());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/js/popper.min.js",
               request => new StaticFilesController().Popper());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/js/bootstrap.min.js",
               request => new StaticFilesController().BootstrapJs());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/login",
                request => new UsersController().Login());
            serverRoutingTable.Add(HttpRequestMethod.Get, "/register",
                request => new UsersController().Register());

            /*<link rel="stylesheet" type="text/css" href="/wwwroot/css/reset-css.css">
           <link rel="stylesheet" type="text/css" href="/wwwroot/css/bootstrap.min.css">
           <link rel="stylesheet" type="text/css" href="/wwwroot/css/style.css">
           <script src="/wwwroot/js/jquery-3.4.1.min.js"></script>
           <script src="/wwwroot/js/popper.min.js"></script>
           <script src="/wwwroot/js/bootstrap.min.js"></script>*/

            return serverRoutingTable;
        }

        public override void ConfigureServices()
        {
            
        }
    }
}
