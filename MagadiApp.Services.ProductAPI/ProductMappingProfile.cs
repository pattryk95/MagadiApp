using AutoMapper;
using MagadiApp.Services.ProductAPI.Models;
using MagadiApp.Services.ProductAPI.Models.Dtos;

namespace MagadiApp.Services.ProductAPI
{
    public class ProductMappingProfile : Profile
    {

        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();


        }

    }
}
