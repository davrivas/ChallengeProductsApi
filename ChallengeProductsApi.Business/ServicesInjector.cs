using ChallengeProductsApi.Data.Repositories;
using ChallengeProductsApi.Data.Repositories.Interfaces;
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
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
