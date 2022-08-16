using SIS.HTTP.Extensions;
using SIS.WebServer;
using SIS.WebServer.Routing;
using SIS.HTTP.Enums;
using System.Diagnostics;
using HTTP_Web_Server.Controllers;
using System.Text;

namespace HTTP_Web_Server
{
    public class Launcher
    {
        const int port = 8000;
        static void Main(string[] args)
        {
      
                
    



    Server server = new Server(port, new StartUp().ConfigureRoutingTable());
            Process.Start(@"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe", $"http://localhost:{port}");
            server.Run();

        }
    }
}