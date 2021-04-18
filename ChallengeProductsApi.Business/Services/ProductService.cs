using ChallengeProductsApi.Business.Models;
using ChallengeProductsApi.Business.Services.Interfaces;
using ChallengeProductsApi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProductsApi.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
            return id;
        }

        public Task<List<ProductModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> InsertAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> SearchProductsAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Update(int id, ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
