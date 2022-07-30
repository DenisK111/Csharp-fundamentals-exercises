using AutoMapper;

namespace Services.Mapper
{
    public static class MapperConfig
    {
        public static readonly MapperConfiguration configuration = new MapperConfiguration(cfg => {
            
            cfg.AddProfile<RealEstateProfile>();
        });

        public static readonly IMapper mapper = configuration.CreateMapper();
    }
}