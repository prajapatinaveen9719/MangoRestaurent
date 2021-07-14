using AutoMapper;
using MangoServices.ProductAPI.DTO;
using MangoServices.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoServices.ProductAPI
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
              {
                 //config.CreateMap<ProductDto, Product>().ReverseMap();
                  config.CreateMap<ProductDto, Product>();
                  config.CreateMap<Product, ProductDto>();

              });
            return mappingConfig;
        }
    }
}
