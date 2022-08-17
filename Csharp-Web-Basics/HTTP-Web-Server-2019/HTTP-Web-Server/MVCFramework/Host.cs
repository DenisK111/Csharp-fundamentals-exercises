using MVCFramework.Attributes;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework
{
    public static class Host
    {

        public static async Task CreateHostAsync(IMVCApplication application, int port)
        {
            application.ConfigureServices();
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            AutoRegisterStaticFiles(serverRoutingTable);
            AutoRegisterRoutes(serverRoutingTable,application);
            application.Configure(serverRoutingTable);


            new Server(port, serverRoutingTable).Run();



        }

        private static void AutoRegisterRoutes(IServerRoutingTable serverRoutingTable,IMVCApplication application)
        {
           var types = application.GetType().Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Controller)));

            foreach (var type in types)
            {
                var methods = type.GetMethods()
                    .Where(m => m.DeclaringType == type && m.IsPublic && !m.IsStatic && !m.IsAbstract && !m.IsConstructor && !m.IsSpecialName);
                
                foreach (var method in methods)
                {
                    var methodName = method.Name;
                    var path = $"/{type.Name.Replace("Controller", String.Empty)}/{methodName}";
                    

                    HttpRequestMethod requestType = MapAttributeToHttpMethod(method,ref path);
                    Console.WriteLine(path);

                  // instance.Request = 
                     
                    
                    serverRoutingTable.Add(requestType, path,
                        request =>
                        {
                            var instance = Activator.CreateInstance(type) as Controller;
                            instance!.Request = request;
                            var response = (IHttpResponse)method.Invoke(instance, null)!;
                            return response;
                        });

                    
                }
            }
        }

        private static HttpRequestMethod MapAttributeToHttpMethod(MethodInfo method,ref string path)
        {
            var attribute = method.GetCustomAttributes().Where(a => a.GetType().IsSubclassOf(typeof(BaseAttribute))).FirstOrDefault()!;

            var baseAttribute = attribute as BaseAttribute;
            if (baseAttribute !=null)
            {
                if (!string.IsNullOrEmpty(baseAttribute!.Url))
                {
                    path = baseAttribute.Url;
                }
                return baseAttribute!.Method;

            }
            return HttpRequestMethod.Get;
            



        }

        private static void AutoRegisterStaticFiles(IServerRoutingTable serverRoutingTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);



            foreach (var staticFile in staticFiles)

            {
                var fileRoute = staticFile.Replace("\\", "/").Replace("wwwroot", String.Empty);

                serverRoutingTable.Add(HttpRequestMethod.Get, fileRoute,
                    request =>
                    {
                        var responseBody = File.ReadAllBytes(staticFile);
                        return new HttpResponse(responseBody, HttpResponseStatusCode.Ok, GetContentType(fileRoute));

                    });
            }
        }



        private static string GetContentType(string fileRoute)
        {
            var extension = Path.GetExtension(fileRoute);

            return extension switch
            {
                ".css" => "text/css",
                ".js" => "application/javascript",
                ".jpeg" => "image/jpeg",
                ".jpg" => "image/jpeg",
                ".html" => "text/html",
                ".txt" => "text/plain",
                ".ico" => "image/x-icon",
                _ => "text/plain"
            };
        }
    }
}
