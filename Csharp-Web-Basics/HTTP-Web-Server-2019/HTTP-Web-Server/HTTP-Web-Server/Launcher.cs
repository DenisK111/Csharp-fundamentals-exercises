using SIS.HTTP.Extensions;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace HTTP_Web_Server
{
    internal class Launcher
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable= new ServerRoutingTable();

            serverRoutingTable.Add(SIS.HTTP.Enums.HttpRequestMethod.Get, "/",
                request => new HomeController().Index(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();

        }
    }
}