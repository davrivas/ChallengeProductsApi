using AutoMapper;
using ChallengeProductsApi.Business.Models;
using ChallengeProductsApi.Business.Services.Interfaces;
using ChallengeProductsApi.Data.Entities;
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
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var productExists = await _productRepository.ProductExists(id);

            if (!productExists)
            {
                throw new Exception($"Product with id {id} does not exist");
            }

            await _productRepository.DeleteAsync(id);
            return id;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> InsertAsync(AddProductModel product)
        {
            var productTypeExists = await _productRepository.ProductTypeExists(product.ProductTypeId);

            if (!productTypeExists)
            {
                throw new Exception($"Product type with id {product.ProductTypeId} does not exist");
            }

            var newProduct = _mapper.Map<Product>(product);
            await _productRepository.InsertAsync(newProduct);

            var returnValue = await _productRepository.GetByIdAsync(newProduct.Id);
            return _mapper.Map<ProductModel>(returnValue);
        }

        public async Task<List<ProductModel>> SearchAsync(string search)
        {
            var products = await _productRepository.SearchAsync(search);
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> Update(int id, AddProductModel product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new Exception($"Product with id {id} does not exist");
            }

            var productTypeExists = await _productRepository.ProductTypeExists(product.ProductTypeId);
            if (!productTypeExists)
            {
                throw new Exception($"Product type with id {product.ProductTypeId} does not exist");
            }

            existingProduct.Description = product.Description;
            existingProduct.IsActive = product.IsActive;
            existingProduct.Price = product.Price;
            existingProduct.ProductTypeId = product.ProductTypeId;
            existingProduct.SoldDate = product.SoldDate;
            await _productRepository.UpdateAsync(existingProduct);

            var returnValue = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductModel>(returnValue);
        }
    }
}
