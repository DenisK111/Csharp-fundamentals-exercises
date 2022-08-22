namespace SharedTrip
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SharedTrip.Data;
    using SharedTrip.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            new ApplicationDbContext().Database.EnsureCreated();
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());
           
            server.ServiceCollection
                .Add<ApplicationDbContext>();
            server.ServiceCollection.Add<IUserService, UserService>();
            server.ServiceCollection.Add<ITripService, TripService>();

          
            await server.Start();
        }
    }
}
