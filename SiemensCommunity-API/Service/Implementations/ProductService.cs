using Common;
using Data.Contracts;
using Microsoft.Extensions.Logging;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;
        private readonly IPhotoRepository _photoRepository;
        private readonly ILogService _logService;
        private readonly ProductAdapter _productAdapter = new ProductAdapter();
        private readonly ProductDTOAdapter _productDTOAdapter = new ProductDTOAdapter();
        private readonly PhotoAdapter _photoAdapter = new PhotoAdapter();
        private readonly ProductFormAdapter _productFormDTOAdapter = new ProductFormAdapter();
        private readonly UpdateProductAdapter _updateProductAdapter = new UpdateProductAdapter();
        private readonly ILogger _logger;

        public ProductService(IProductRepository productRepository, IPhotoService photoService, IPhotoRepository photoRepository, ILoggerFactory logger, ILogService logService)
        {
            _productRepository = productRepository;
            _photoService = photoService;
            _photoRepository = photoRepository;
            _logService = logService;
            _logger = logger.CreateLogger("ProductService");
        }

        public async Task<Product> AddAsync(AddProduct addProduct)
        {
            Data.Models.Product returnedProduct = new Data.Models.Product();

            var result = await _photoService.UploadPhotoAsync(addProduct.File);
            var image = new Photo();
            if (result == null || result.Error != null)
            {
                _logger.LogError(MyLogEvents.ErrorUploadItem, "Error uploading photo with errors " + result.Error);

            }
            image = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                IsMain = false
            };
            try
            {
                var photoInDb = await _photoRepository.AddAsync(_photoAdapter.Adapt(image));
                var adaptedProduct = _productAdapter.AdaptAddProductToProduct(addProduct);
                adaptedProduct.Photo = photoInDb;
                adaptedProduct.PhotoId = photoInDb.Id;
                adaptedProduct.IsAvailable = true;
                returnedProduct = await _productRepository.AddAsync(adaptedProduct);
                _logger.LogInformation(MyLogEvents.InsertItem, "Product successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.InsertItem, "Error while inserting product wiht message " + ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.InsertItem, ex.Message, ex.StackTrace);
            }

            return _productAdapter.Adapt(returnedProduct);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            bool result = false;

            try
            {
                result = await _productRepository.DeleteByIdAsync(id);
                _logger.LogInformation(MyLogEvents.InsertItem, "Successful insertion of product with id = {id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.InsertItem, "Error while deleting item with id={id}, with error {eroror}.", id, ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.InsertItem, ex.Message, ex.StackTrace);
            }

            return result;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            IEnumerable<Product> products = new List<Product>();

            try
            {
                var returnedProducts = await _productRepository.GetAsync();
                products = _productAdapter.AdaptList(returnedProducts);
                _logger.LogInformation(MyLogEvents.ListItems, "Got {count} products", returnedProducts.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.ListItems, "Error while getting product with message " + ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
            }

            return products;
        }

        public async Task<ProductFormDTO> GetByIdAsync(int id)
        {
            ProductFormDTO product = new ProductFormDTO();
            try
            {
                var returnedProduct = await _productRepository.FindById(id);
                product = _productFormDTOAdapter.Adapt(returnedProduct);
                _logger.LogInformation(MyLogEvents.GetItem, "Getting item with id={id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.GetItem, "Error while getting item with id={id}, with error {error}", id, ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.GetItem, ex.Message, ex.StackTrace);
            }
            return product;
        }

        public async Task<Product> UpdateAsync(UpdateProductDTO product)
        {
            var photoInDb = await _photoRepository.FindByURL(product.ImageURL);

            var oldPhotoId = photoInDb.Id;

            var photo = _photoService.SavePhoto(product.File);
            if(photo!= null)
            {
                product.PhotoId = photoInDb.Id;
            }
            Product updatedProduct = new Product();
            try
            {
                var productReturned = await _productRepository.UpdateAsync(_updateProductAdapter.Adapt(product), product.Id);
                updatedProduct = _productAdapter.Adapt(productReturned);
            }catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.UpdateItem, "Error while trying to update product with id=" + product.Id + " with message " + ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.UpdateItem, ex.Message, ex.StackTrace);
            }

            if (oldPhotoId != photoInDb.Id)
                await _photoRepository.DeleteByIdAsync(photoInDb.Id);

            return updatedProduct;
        }

        public async Task<List<ProductDTO>> GetFiltredProducts(int selectedCategory, int selectedOption)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            try
            {
                var returnedProducts = await _productRepository.GetFiltredProducts(selectedCategory, selectedOption);
                products = _productDTOAdapter.AdaptList(returnedProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.ListItems, "Error while getting the filtered products of for home page ", ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
            }
            return products;
        }

        public async Task<List<ProductDTO>> GetUserProductsAsync(int userId, int? selectedCategoryId)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            if (selectedCategoryId == null)
            {
                try
                {
                    var productsRetuned = await _productRepository.GetUserProductsAsync(userId);
                    products = _productDTOAdapter.AdaptList(productsRetuned);
                }catch(Exception ex)
                {
                    _logger.LogError(MyLogEvents.ListItems, "Error while getting the filtered products of for home page ", ex.Message);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
                }
            }
            else
            {
                try
                {
                    var productsReturned = await _productRepository.GetUserProductsByCategoryAsync(userId, selectedCategoryId.Value);
                    products = _productDTOAdapter.AdaptList(productsReturned);
                }catch(Exception ex)
                {
                    _logger.LogError(MyLogEvents.ListItems, "Error while getting the filtered products of for home page ", ex.Message);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
                }
            }
            return products;
        }

        public async Task<List<ProductDTO>> GetUserAvailableProductsAsync(int userId, int? selectedCategoryId)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            if (selectedCategoryId == null)
            {
                try
                {
                    var productsReturned = await _productRepository.GetUserAvailableProductsAsync(userId);
                    products = _productDTOAdapter.AdaptList(productsReturned);
                    _logger.LogInformation(products.Count() + "products found available of all categories, of user with id " + userId);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Get user available products error with message " + ex.Message + ex.StackTrace);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.GetItem, ex.Message, ex.StackTrace);
                }

            }
            else
            {
                try
                {
                    var productsReturned = await _productRepository.GetUserAvailableProductsByCategoryAsync(userId, selectedCategoryId.Value);
                    products = _productDTOAdapter.AdaptList(productsReturned);
                    _logger.LogInformation(products.Count() + "products found of user with id " + userId + "category id " + selectedCategoryId);
                }catch(Exception ex)
                {
                    _logger.LogError("Get user available products error with message " + ex.Message + ex.StackTrace);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.GetItem, ex.Message, ex.StackTrace);
                }
            }

            return products;
        }

        public async Task<List<ProductDTO>> GetUserLendProductsAsync(int userId, int? selectedCategoryId)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            if (selectedCategoryId == null)
            {
                try
                {
                    var productsReturned = await _productRepository.GetUserLendProductsAsync(userId);
                    products = _productDTOAdapter.AdaptList(productsReturned);
                }catch(Exception ex)
                {
                    _logger.LogError("Get user available products error with message " + ex.Message + ex.StackTrace);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.GetItem, ex.Message, ex.StackTrace);
                }
            }
            else
            {
                try
                {
                    var productsReturned = await _productRepository.GetUserLendProductsByCategoryAsync(userId, selectedCategoryId.Value);
                    products = _productDTOAdapter.AdaptList(productsReturned);
                }catch(Exception ex)
                {
                    _logger.LogError("Get user available products error with message " + ex.Message + ex.StackTrace);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.GetItem, ex.Message, ex.StackTrace);
                }
            }
            return products;
        }
    }
}
