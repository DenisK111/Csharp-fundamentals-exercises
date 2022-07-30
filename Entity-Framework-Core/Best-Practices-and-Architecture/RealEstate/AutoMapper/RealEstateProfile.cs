using AutoMapper;
using Importer.ImportDtos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperProj
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            this.CreateMap<ImportPropertyDto,Property>
        }
    }
}
