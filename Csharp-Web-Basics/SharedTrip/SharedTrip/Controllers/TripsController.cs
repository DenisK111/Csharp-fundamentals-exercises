using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Services;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService service;

        public TripsController(Request request, ITripService service) : base(request)
        {
            this.service = service;
        }

        public Response All()
        {

            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");

            var response = service.GetAllTrips();

            var viewModel = new
            {
                IsAuthenticated = true,
                Model = response
            };

            return this.View(viewModel);
        }
        [HttpPost]
        public Response Add(InputTripModel model)
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            if (model.Seats<2 || model.Seats > 6)
            {
                return Add();
            }

            if (model.Description.Length > 80)
            {
                return Add();
            }

          
            service.AddTripToDb(model);

            return Redirect("/");
        }

        public Response Add()
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            return this.View(new { IsAuthenticated = true });
        }

        public Response Details(string tripId)
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            var details = service.GetTripDetails(tripId);
            var viewModel = new
            {
                IsAuthenticated = true,
                Model = details
            };
            return this.View(viewModel);
        }

        
        public Response AddUserToTrip(string tripId)
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            if (!service.AddUserToTrip(tripId,this.User.Id))
            {
                return this.Details(tripId);
            }
            
            return Redirect("/");
        }

    }
}
