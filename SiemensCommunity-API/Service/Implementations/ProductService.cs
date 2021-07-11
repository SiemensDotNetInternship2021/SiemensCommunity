using AutoMapper;
using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductAdapter _productAdapter = new ProductAdapter();

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var returnedProduct =  await _productRepository.AddAsync(_productAdapter.Adapt(product));
            return _productAdapter.Adapt(returnedProduct);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _productRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var returnedProducts = await _productRepository.GetAsync();
            return _productAdapter.AdaptList(returnedProducts);
        }
    }
}
