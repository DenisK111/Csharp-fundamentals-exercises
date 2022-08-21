namespace FootballManager
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using FootballManager.Data;
    using FootballManager.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            new FootballManagerDbContext().Database.EnsureCreated();

            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

          
            server.ServiceCollection
                .Add<FootballManagerDbContext> ();
            server.ServiceCollection
                .Add<IPlayersService, PlayersService>();
           
            await server.Start();
        }
    }
}
