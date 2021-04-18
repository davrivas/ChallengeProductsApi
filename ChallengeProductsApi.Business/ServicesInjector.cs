using ChallengeProductsApi.Business.Mapper;
using ChallengeProductsApi.Business.Services;
using ChallengeProductsApi.Business.Services.Interfaces;
using ChallengeProductsApi.Data.Context;
using ChallengeProductsApi.Data.Repositories;
using ChallengeProductsApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Business
{
    public static class ServicesInjector
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapper>();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var connectionString = configuration.GetConnectionString("Local");
            services.AddDbContext<ProductContext>(options =>
                   options.UseSqlServer(connectionString));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
