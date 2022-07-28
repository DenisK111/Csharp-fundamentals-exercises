using AutoMapper;
using ProductShop.Dto.Imported;
using ProductShop.Models;
using System.Collections.Generic;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UsersUser, User>();
            this.CreateMap<ProductsProduct, Product>();
            this.CreateMap<CategoriesCategory, Category>();
            this.CreateMap<CategoryProductsCategoryProduct, CategoryProduct>();
                
                
        }
    }
}
