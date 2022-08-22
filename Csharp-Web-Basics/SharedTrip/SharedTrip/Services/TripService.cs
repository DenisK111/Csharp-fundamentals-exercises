using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext context;

        public TripService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddTripToDb(InputTripModel model)
        {
            var trip = new Trip
            {

                DepartureTime = model.DepartureTime,
                Seats = model.Seats,
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                Description = model.Description,



            };
            context.Trips.Add(trip);
            context.SaveChanges();
        }

        public bool AddUserToTrip(string tripId,string username)
        {
            if (this.context.UserTrips.Any(x=>x.TripId == tripId && x.User.Username == username))
            {
                return false;
            }
            var trip = this.context.Trips.Find(tripId);
            var user = this.context.Users.First(x => x.Username == username);

            this.context.UserTrips.Add(new UserTrip
            {
                Trip=trip,
                TripId=trip.Id,
                User=user,
                UserId=user.Id

            });

            context.SaveChanges();
            return true;
        }

        public IEnumerable<TripViewModel> GetAllTrips()
        {

            var result = context.Trips
                .Select(t => new TripViewModel
                {
                    Id = t.Id,
                    DepartureTime = t.DepartureTime,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Description = t.Description,
                    Seats = t.Seats - context.UserTrips.Where(x => x.TripId == t.Id).Count()

        })

                .ToList();

            return result;
        }

        public IEnumerable<TripViewModel> GetTripDetails(string tripId)
        {
            var takenSeats = context.UserTrips.Where(x => x.TripId == tripId).Count();
            var trip = context.Trips.Where(x=>x.Id==tripId).Select(trip=>
            
            new TripViewModel()
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime,
                Description = trip.Description,
                ImagePath = trip.ImagePath,
                Seats = trip.Seats - takenSeats,

            });

            return trip;
        }
    }
}
