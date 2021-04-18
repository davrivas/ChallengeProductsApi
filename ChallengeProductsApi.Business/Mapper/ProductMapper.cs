using AutoMapper;
using ChallengeProductsApi.Business.Models;
using ChallengeProductsApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Business.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(
                    dest => dest.ProductType,
                    opt => opt.MapFrom(a => a.ProductType.Name)
                );
            CreateMap<Product, AddProductModel>();

            CreateMap<AddProductModel, Product>();
            CreateMap<ProductModel, Product>();
        }
    }
}
