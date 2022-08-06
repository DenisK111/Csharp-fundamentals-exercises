namespace Theatre
{
    using System;
    using System.Globalization;
    using AutoMapper;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ImportDto;

    class TheatreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public TheatreProfile()
        {
           

            this.CreateMap<ImportPlaysXmlDto, Cast>()
                .ForMember(x=>x.PlayId,y=>y.MapFrom(s=>s.PlayId));
            this.CreateMap<ImportPlaysRealXmlDto, Play>()

                .ForMember(x=>x.Duration,y=>y.MapFrom(s=> TimeSpan.ParseExact(s.Duration,"c",CultureInfo.InvariantCulture)));
        }

        
    }
}
