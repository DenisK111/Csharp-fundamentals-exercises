namespace TeisterMask
{
    using AutoMapper;
    using System;
    using System.Globalization;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
           // this.CreateMap<ImportProjectsDto, Project>()
           //     .ForMember(x => x.OpenDate, y => y.MapFrom(s => DateTime.ParseExact(s.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
           //     .ForMember(x => x.DueDate, y => y.MapFrom(s => DateTime.TryParseExact(s.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, 0, /out/ DateTime result) ? result : null)) ;
           //
           // this.CreateMap<TaskDto,Task>()
           //     .ForMember(x => x.OpenDate, y => y.MapFrom(s => DateTime.ParseExact(s.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
           //     .ForMember(x => x.DueDate, y => y.MapFrom(s => DateTime.ParseExact(s.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
           //

        }
    }
}
