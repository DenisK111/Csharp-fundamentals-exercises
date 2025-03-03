﻿using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
          
            return this.View(new { IsAuthenticated = false });
        }
    }
}