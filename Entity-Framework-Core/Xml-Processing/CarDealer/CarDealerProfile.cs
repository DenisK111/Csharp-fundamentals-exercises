using AutoMapper;
using CarDealer.Dto.Import;

using CarDealer.Models;
using System;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<PartsPart, Part>();
            this.CreateMap<SuppliersSupplier, Supplier>();
            this.CreateMap<CustomersCustomer, Customer>();
            this.CreateMap<SalesSale, Sale>();



           // this.CreateMap<CarsCar, Car>()
             //  .ForMember(x => x.TravelledDistance, y => y.MapFrom(s => s.TraveledDistance));
              

        }
    }
}
