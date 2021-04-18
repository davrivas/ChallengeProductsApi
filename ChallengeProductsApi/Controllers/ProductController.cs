using ChallengeProductsApi.Business.Models;
using ChallengeProductsApi.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeProductsApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ProductModel>>> Search(string q)
        {
            return await _productService.SearchProductsAsync(q);
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Insert(ProductModel productModel)
        {
            return await _productService.InsertAsync(productModel);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductModel> Update(ProductModel productModel, int id)
        {
            return _productService.Update(id, productModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _productService.DeleteAsync(id);
        }
    }
}
