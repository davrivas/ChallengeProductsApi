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
            CreateMap<Product, ProductModel>();
            CreateMap<Product, AddProductModel>();

            CreateMap<AddProductModel, Product>();
            CreateMap<ProductModel, Product>();
        }
    }
}
