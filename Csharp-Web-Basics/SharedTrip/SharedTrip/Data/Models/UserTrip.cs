using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public User User { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public Trip Trip { get; set; } = null!;

        public string TripId { get; set; } = null!;

        /*⦁	Has UserId – a string
        ⦁	Has User – a User object
        ⦁	Has TripId– a string
        ⦁	Has Trip – a Trip object
        */
    }
}
