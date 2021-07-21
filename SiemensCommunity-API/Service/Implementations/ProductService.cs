using AutoMapper;
using Data.Contracts;
using Microsoft.AspNetCore.Http;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ProductFormAdapter _productFormDTOAdapter = new ProductFormAdapter();

        public ProductService(IProductRepository productRepository, IPhotoService photoService, IPhotoRepository photoRepository)
        {
            _productRepository = productRepository;
            _photoService = photoService;
            _photoRepository = photoRepository;
        }

        public async Task<Product> AddAsync(AddProduct addProduct)
        {
            var image = new Photo();
            var photoInDb = new Data.Models.Photo();
            var returnedProduct = new Data.Models.Product();
            if (addProduct.ImageURL == "" || addProduct.ImageURL == null)
            {
                var result = await _photoService.UploadPhohoAsync(addProduct.Image);
                if (result.Error != null)
                {
                    //return error
                }
                image.Url = result.SecureUrl.AbsoluteUri;
                image.PublicId = result.PublicId;
                image.IsMain = false;
                photoInDb = await _photoRepository.AddAsync(_photoAdapter.Adapt(image));

            }
            else
            {
                photoInDb = await _photoRepository.FindByURL(addProduct.ImageURL);
            }
            
            var adaptedProduct = _productAdapter.AdaptAddProductToProduct(addProduct);
            adaptedProduct.Photo = photoInDb;
            adaptedProduct.PhotoId = photoInDb.Id;
            if(adaptedProduct.Id == 0)
            {
               returnedProduct = await _productRepository.AddAsync(adaptedProduct);
            }
            else
            {
                returnedProduct = await _productRepository.UpdateAsync(adaptedProduct, adaptedProduct.Id);
            }
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

        public async Task<ProductFormDTO> GetByIdAsync(int id)
        {
            var returnedProduct = await _productRepository.FindById(id);
            return _productFormDTOAdapter.Adapt(returnedProduct);
        }
    }
}
