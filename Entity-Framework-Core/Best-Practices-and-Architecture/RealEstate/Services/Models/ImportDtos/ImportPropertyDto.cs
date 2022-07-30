using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.ImportDtos
{

    public class ImportPropertyDto
    {
        public ImportPropertyDto()
        {
            Properties = new HashSet<IProperty>();
        }
        public ICollection<IProperty> Properties { get; set; }
    }

    public class PropertyDto : IProperty
    {

        public int Size { get; set; }
        public int YardSize { get; set; }
        public byte Floor { get; set; }
        public byte TotalFloors { get; set; }
        public string District { get; set; } = null!;
        public int Year { get; set; }
        public string Type { get; set; } = null!;
        public string BuildingType { get; set; } = null!;
        public int Price { get; set; }
    }

}
