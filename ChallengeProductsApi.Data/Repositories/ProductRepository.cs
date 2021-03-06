using ChallengeProductsApi.Data.Context;
using ChallengeProductsApi.Data.Entities;
using ChallengeProductsApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProductsApi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.ProductType)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.ProductType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProductExists(int id)
        {
            return await _context.Products.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ProductTypeExists(int id)
        {
            return await _context.ProductTypes.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Product>> SearchAsync(string search)
        {
            return await _context.Products
                .Include(x => x.ProductType)
                .Where(x => EF.Functions.Like(x.Description, $"%{search}%"))
                .ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
