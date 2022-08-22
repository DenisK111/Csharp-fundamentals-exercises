using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        IEnumerable<TripViewModel> GetAllTrips();

        void AddTripToDb(InputTripModel model);

        IEnumerable<TripViewModel> GetTripDetails(string tripId);
        bool AddUserToTrip(string tripId,string username);
    }
}
