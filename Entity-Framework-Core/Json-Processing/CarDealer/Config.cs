using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public static class Config
    {
        public static readonly MapperConfiguration settings = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();

        });

        public static readonly IMapper mapper = settings.CreateMapper();

        public static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
            
        };
    }
}
