// ReSharper disable InconsistentNaming
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProductShop.Common
{
    public static class GlobalConstants
    {
        //User
        public const int UserLastNameMinLength = 3;

        //Product
        public const int ProductNameMinLength = 3;

        public static readonly MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
        public static readonly IMapper mapper = config.CreateMapper();
        public static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
           
            
            
        };
    }
}
