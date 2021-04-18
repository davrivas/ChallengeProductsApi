using ChallengeProductsApi.Data.Entities;
using ChallengeProductsApi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProductsApi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SearchProductsAsync(string search)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
