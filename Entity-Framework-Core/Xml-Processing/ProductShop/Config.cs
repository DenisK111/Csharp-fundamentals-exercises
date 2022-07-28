using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop
{
    public static class Config
    {
        public static readonly MapperConfiguration settings = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        });
        public static readonly IMapper mapper = settings.CreateMapper();
    }
}
