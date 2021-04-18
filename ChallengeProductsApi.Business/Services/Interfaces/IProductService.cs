﻿using ChallengeProductsApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProductsApi.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(int id);
        Task<List<ProductModel>> SearchProductsAsync(string search);
        Task<ProductModel> InsertAsync(ProductModel product);
        Task<ProductModel> Update(int id, ProductModel product);
        Task<int> DeleteAsync(int id);
    }
}
