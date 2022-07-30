using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Contracts;
using Services.Helpers.EqualityComparers;
using Services.Mapper;
using Services.Models.ExportDto;
using Services.Models.ImportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly RealEstateContext context;

        public PropertyService(RealEstateContext context)
        {
            this.context = context;
        }
        public void Add(int size, int yardSize, byte floor, byte totalFloors, string inputDistrict, int year, string inputPropertyType, string inputBuildingType, int price)
        {
            var model = new Property
            {
                Size = size <= 0 ? 0 : size,
                YardSize = (yardSize <= 0 || yardSize > 255) ? null : yardSize,
                Floor = (floor <= 0 || floor > 255) ? null : floor,
                TotalFloors = (totalFloors <= 0 || totalFloors > 255) ? null : totalFloors,
                Year = year,
                Price = price <= 0 ? null : price,

            };

            var buildingType = context.BuildingTypes.FirstOrDefault(t => t.Name == inputBuildingType) ?? new BuildingType { Name = inputBuildingType };
            
            model.BuildingType = buildingType;


            var propertyType = context.PropertyTypes.FirstOrDefault(t => t.Name == inputPropertyType) ?? new PropertyType { Name = inputPropertyType };
            
            model.Type = propertyType;


            var district = context.Districts.FirstOrDefault(t => t.Name == inputDistrict) ?? new District { Name = inputDistrict };
           
            model.District = district;



            context.Add(model);
            context.SaveChanges();
        }

        public void AddRange(PropertyDto[] range)
        {
            var hashSets = GetHashSets();

            foreach (var dto in range)
            {
                var model = new Property
                {
                    Size = dto.Size <= 0 ? 0 : dto.Size,
                    YardSize = (dto.YardSize <= 0 || dto.YardSize > 255) ? null : dto.YardSize,
                    Floor = (dto.Floor <= 0 || dto.Floor > 255) ? null : dto.Floor,
                    TotalFloors = (dto.TotalFloors <= 0 || dto.TotalFloors > 255) ? null : dto.TotalFloors,
                    Year = dto.Year,
                    Price = dto.Price <= 0 ? null : dto.Price,

                };

                var buildingType = hashSets.buildingTypes.FirstOrDefault(t => t.Name == dto.BuildingType) ?? new BuildingType { Name = dto.BuildingType };
                hashSets.buildingTypes.Add(buildingType);
                model.BuildingType = buildingType;


                var propertyType = hashSets.propertyTypes.FirstOrDefault(t => t.Name == dto.Type) ?? new PropertyType { Name = dto.Type };
                hashSets.propertyTypes.Add(propertyType);
                model.Type = propertyType;


                var district = hashSets.districts.FirstOrDefault(t => t.Name == dto.District) ?? new District { Name = dto.District };
                hashSets.districts.Add(district);
                model.District = district;


               
                context.Add(model);
            }
            context.SaveChanges();



        }

        public decimal GetAvaragePriceBySquareMeters(int from, int to)
        {
            return (decimal)context.Properties.Where(p => p.Size >= from && p.Size <= to && p.Price != null).Average(p => p.Price)!;
        }

        public IEnumerable<ExportAvgPricePerSqmDto> GetAvaragePricePerSqmPerDistrict()
        {
            return MapperConfig.mapper.ProjectTo<ExportAvgPricePerSqmDto>(context.Districts).OrderByDescending(o => o.Price).ToList();
        }

        public IEnumerable<ExportNeighbourhoodsByHighestPriceDTO> GetListOfNeighbourhoodsOrderedByHighestPrice()
        {
            return MapperConfig.mapper.ProjectTo<ExportNeighbourhoodsByHighestPriceDTO>(context.Districts).OrderByDescending(o=>o.AvaragePrice).ToList();
                                
        }

        private (HashSet<District> districts, HashSet<PropertyType> propertyTypes, HashSet<BuildingType> buildingTypes) GetHashSets()
        {


            var hashSetDistricts = new HashSet<District>(new DistrictComparer());

            var districts = context.Districts.AsEnumerable();

            foreach (var distr in districts)
            {

                hashSetDistricts.Add(distr);
            }

            var hashSetPropertyTypes = new HashSet<PropertyType>(new PropertyTypeComparer());


            var propertyTypes = context.PropertyTypes.AsEnumerable();

            foreach (var pType in propertyTypes)
            {

                hashSetPropertyTypes.Add(pType);
            }

            var hashSetBuildingTypes = new HashSet<BuildingType>(new BuildingTypeComparer());

            var buildingTypes = context.BuildingTypes.AsEnumerable();

            foreach (var bType in buildingTypes)
            {

                hashSetBuildingTypes.Add(bType);
            }

            return (hashSetDistricts, hashSetPropertyTypes, hashSetBuildingTypes);

        }
    }
}
