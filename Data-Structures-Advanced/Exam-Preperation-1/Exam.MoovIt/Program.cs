using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    class Program
    {
        static void Main(string[] args)
        {
     
            var moovIt = new MoovIt();

            Route route = new Route("Test1", 10D, 200, true, new List<string>(new string[] { "Sofia", "Plovdiv", "Stara Zagora", "Burgas" }));
            Route route2 = new Route("Test2", 10D, 1, true, new List<string>(new string[] { "Vidin", "Pleven", "Veliko Turnovo", "Varna", "Burgas" }));
            Route route3 = new Route("Test3", 10D, 400, false, new List<string>(new string[] { "Vraca", "Plovdiv", "Stara Zagora", "Varna", "Burgas" }));
            Route route4 = new Route("Test4", 500D, 500, false, new List<string>(new string[] { "Sofia", "Plovdiv", "Stara Zagora", "Varna", "Burgas" }));
            Route route5 = new Route("Test4", 500D, 500, true, new List<string>(new string[] {  "Stara Zagora", "Varna", "adw" , "Burgas"}));
            Route route6 = new Route("Test4", 500D, 500, false, new List<string>(new string[] { "Plovdiv", "Varna", "Burgas" }));
            Route route7 = new Route("Test4", 500D, 500, false, new List<string>(new string[] {}));


            moovIt.AddRoute(route);
            moovIt.AddRoute(route2);
            moovIt.AddRoute(route3);
            moovIt.AddRoute(route4);
            moovIt.AddRoute(route5);
            moovIt.AddRoute(route6);
            moovIt.AddRoute(route7);

            List<Route> routes = moovIt.GetFavoriteRoutes("Burgas").ToList();
            ;

            Console.ReadLine();
        }
    }
}