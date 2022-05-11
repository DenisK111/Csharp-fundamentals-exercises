using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.Data.Models
{
    public class Car
    {
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string PlateNumber { get; set; }
    }
}
