using Services.Models.ExportDto;
using Services.Models.ImportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPropertyService
    {
        public void Add(int size,int YardSize,byte floor,byte totalFloors,string district, int year, string type,string buildingType,int price);

        /*   public int Size { get; set; }
        public int YardSize { get; set; }
        public byte Floor { get; set; }
        public byte TotalFloors { get; set; }
        public string District { get; set; } = null!;
        public int Year { get; set; }
        public string Type { get; set; } = null!;
        public string BuildingType { get; set; } = null!;
        public int Price { get; set; }*/

        public void AddRange(PropertyDto[] dto);

        public decimal GetAvaragePriceBySquareMeters(int from, int to);

        public IEnumerable<ExportNeighbourhoodsByHighestPriceDTO> GetListOfNeighbourhoodsOrderedByHighestPrice();

        public IEnumerable<ExportAvgPricePerSqmDto> GetAvaragePricePerSqmPerDistrict();

    }
}
