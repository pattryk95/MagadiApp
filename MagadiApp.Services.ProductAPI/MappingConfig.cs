using AutoMapper;
using MagadiApp.Services.ProductAPI.DbContexts.Models;
using MagadiApp.Services.ProductAPI.DbContexts.Models.Dtos;

namespace MagadiApp.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
