using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Property
    {

        public Property()
        {
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public int Size { get; set; }

        public int? YardSize { get; set; }

        public byte? Floor { get; set; }
        public byte? TotalFloors { get; set; }

        public int DistrictId { get; set; }
        public District? District { get; set; }

        public int Year { get; set; }
        public int TypeId { get; set; }
        public PropertyType? Type { get; set; }

        public int BuildingTypeId { get; set; }
        public BuildingType? BuildingType { get; set; }
        /// <summary>
        /// Price of the property in Euros
        /// </summary>
        public int? Price { get; set; }

        public ICollection<Tag> Tags { get; set; }




        /*      Size(in square meters)
      YardSize(in square meters, for houses only)
      Floor in which the property is located
      Total number of floors in the building
      District name
      Building year(if no year is specified the value is 0)
      Type of the property(1-room apartment, 2-rooms apartment, studio, etc.)
      Type of the building(brick, panel, etc.)
      Price(in EUR)
      Tags for each property(e.g., OldProperty, HugeApartment, HighFloor, etc.)
        */

    }
}
