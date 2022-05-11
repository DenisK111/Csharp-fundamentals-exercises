using ParkingSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.Data
{
    public class DataAccess
    {
        public static List<Car> Cars { get; set; } = new List<Car>();
    }
}
