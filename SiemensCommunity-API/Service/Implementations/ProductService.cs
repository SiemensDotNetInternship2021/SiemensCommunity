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
        private readonly IPhotoService _photoService;
        private readonly IPhotoRepository _photoRepository;
        private readonly ProductAdapter _productAdapter = new ProductAdapter();
        private readonly ProductAdapter _addProductAdapter = new ProductAdapter();
        private readonly PhotoAdapter _photoAdapter = new PhotoAdapter();

        public ProductService(IProductRepository productRepository, IPhotoService photoService, IPhotoRepository photoRepository)
        {
            _productRepository = productRepository;
            _photoService = photoService;
            _photoRepository = photoRepository;
        }

        public async Task<Product> AddAsync(AddProduct addProduct)
        {
            var result = await _photoService.AddPhotoAsync(addProduct.Image);
            if (result.Error != null)
            {
                //return error
            }
            
            var adaptedProduct = _productAdapter.AdaptAddProductToProduct(addProduct);
            var image = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                IsMain = false
            };
            var photoInDb = await _photoRepository.AddAsync(_photoAdapter.Adapt(image));
            adaptedProduct.Photo = photoInDb;
            adaptedProduct.PhotoId = photoInDb.Id;

            var returnedProduct = await _productRepository.AddAsync(adaptedProduct);
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
