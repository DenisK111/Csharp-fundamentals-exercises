using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public static class Config
    {
        public static readonly MapperConfiguration settings = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        });
        public static readonly IMapper mapper = settings.CreateMapper();
    }
}
