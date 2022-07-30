using AutoMapper;
using Models;
using Services.Models.ExportDto;
using Services.Models.ImportDtos;
using Property = Models.Property;

namespace Services.Mapper
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            this.CreateMap<District, ExportNeighbourhoodsByHighestPriceDTO>()
                .ForMember(x=>x.AvaragePrice,y=>y.MapFrom(s=>(decimal)s.Properties.Where(p=>p.Price != null).Average(p=>p.Price)!));

            this.CreateMap<District, ExportAvgPricePerSqmDto>()
                .ForMember(x => x.Price, y => y.MapFrom(s => (decimal)s.Properties.Where(p => p.Price != null).Average(p => p.Price / p.Size)!));
        }
    }
}
