using MVCFramework.Attributes;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
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
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            IServiceCollection serviceCollection = new ServiceCollection();
            application.ConfigureServices(serviceCollection);

            AutoRegisterStaticFiles(serverRoutingTable);
            AutoRegisterRoutes(serverRoutingTable, application, serviceCollection);
            application.Configure(serverRoutingTable);


            new Server(port, serverRoutingTable).Run();



        }

        private static void AutoRegisterRoutes(IServerRoutingTable serverRoutingTable, IMVCApplication application, IServiceCollection serviceCollection
            )
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


                    HttpRequestMethod requestType = MapAttributeToHttpMethod(method, ref path);
                    Console.WriteLine(path);

                    // instance.Request = 


                    serverRoutingTable.Add(requestType, path,
                        request => ExecuteAction(request!, serviceCollection, method, type)

                        );


                }
            }
        }

        private static IHttpResponse ExecuteAction(IHttpRequest request, IServiceCollection serviceCollection, MethodInfo? method, Type? type)
        {
            var instance = serviceCollection.CreateInstance(type!) as Controller;
            var arguments = new List<object>();
            var parameters = method?.GetParameters();

            foreach (var parameter in parameters!)
            {
                var parameterValue = GetParameterFromRequest(request, parameter.Name!);
                
                var paramsParameterValue = Convert.ChangeType(parameterValue, parameter.ParameterType);

                if (paramsParameterValue == null && parameter.ParameterType != typeof(string))
                {
                    paramsParameterValue = Activator.CreateInstance(parameter.ParameterType);
                    var properties = parameter.ParameterType.GetProperties();

                    foreach (var property in properties)
                    {
                        var propertyHttpValue = GetParameterFromRequest(request, property.Name!);
                        var propertyParameterValue = Convert.ChangeType(propertyHttpValue, property.PropertyType);
                        property.SetValue(paramsParameterValue, propertyParameterValue);
                    }
                }

                arguments.Add(paramsParameterValue!);
            }

            instance!.Request = request;
            var response = (IHttpResponse)method!.Invoke(instance, arguments.ToArray())!;
            return response!;

        }

        private static object? GetParameterFromRequest(IHttpRequest request, string parameterName)
        {
            parameterName = parameterName.ToLower();
            return request.FormData.Any(x => x.Key.ToLower() == parameterName)
                 ? request.FormData.First(x => x.Key.ToLower() == parameterName).Value
                 : request.QueryData.Any(x => x.Key.ToLower() == parameterName)
                 ? request.QueryData.First(x => x.Key.ToLower() == parameterName).Value
                 : null;
        }

        private static HttpRequestMethod MapAttributeToHttpMethod(MethodInfo method, ref string path)
        {
            var attribute = method.GetCustomAttributes().Where(a => a.GetType().IsSubclassOf(typeof(BaseAttribute))).FirstOrDefault()!;

            var baseAttribute = attribute as BaseAttribute;
            if (baseAttribute != null)
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
                ".png" => "image/png",
                ".html" => "text/html",
                ".txt" => "text/plain",
                ".ico" => "image/x-icon",
                _ => "text/plain"
            };
        }
    }
}
