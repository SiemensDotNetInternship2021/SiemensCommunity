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
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IFavoriteProductRepository _favoriteProductRepository;
        private readonly FavoriteProductAdapter _favoriteProductAdapter = new FavoriteProductAdapter();
        private readonly FavoriteProductDTOAdapter _favoriteProductDTOAdapter = new FavoriteProductDTOAdapter();
        private readonly ILogger _logger;
        private readonly ILogService _logService;

        public FavoriteProductService(IFavoriteProductRepository departmentRepository, Microsoft.Extensions.Logging.ILoggerFactory logger, ILogService logService)
        {
            _favoriteProductRepository = departmentRepository;
            _logger = logger.CreateLogger("FavoriteProductService");
            _logService = logService;
        }

        public async Task<IEnumerable<FavoriteProductDTO>> GetAsync(int userId, int selectedCategory, int selectedOption)
        {
            IEnumerable<Data.Models.FavoriteProductDTO> returnedFavoriteProducts = new List<Data.Models.FavoriteProductDTO>();
            try
            {
                 returnedFavoriteProducts = await _favoriteProductRepository.GetAsync(userId, selectedCategory, selectedOption);
                _logger.LogInformation(MyLogEvents.ListItems, "Getting List of Favorite Products, {count} found", returnedFavoriteProducts.Count());
            }
            catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.ListItems, "Error while getting favorite product with message " + ex.Message);
            }
            return _favoriteProductDTOAdapter.AdaptList(returnedFavoriteProducts);
        }

        public async Task<FavoriteProduct> AddAsync(FavoriteProduct productDetails)
        {
            Data.Models.FavoriteProduct returnedProduct = new Data.Models.FavoriteProduct();
            try
            {
                returnedProduct = await _favoriteProductRepository.AddAsync(_favoriteProductAdapter.Adapt(productDetails));
                _logger.LogInformation(MyLogEvents.InsertItem, "Product successfully added");
            }
            catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.InsertItem, "Error while inserting favorite product with message " + ex.Message);
            }
            return _favoriteProductAdapter.Adapt(returnedProduct);

        }

        public async Task<FavoriteProduct> DeleteAsync(FavoriteProduct productDetails)
        {
            Data.Models.FavoriteProduct returnedProduct = new Data.Models.FavoriteProduct();
            try
            {
                returnedProduct = await _favoriteProductRepository.DeleteAsync(_favoriteProductAdapter.Adapt(productDetails));
                _logger.LogInformation(MyLogEvents.DeleteItem, "Successful deletion of favorite product with id={ProductId} for user userid = {UserId}", productDetails.ProductId, productDetails.UserId);
            }
            catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.DeleteItem, "Error while deleting item with id={ProductId} for user userId={UserId}, with error {error}", productDetails.ProductId, productDetails.UserId, ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.DeleteItem, ex.Message, ex.StackTrace);
            }
            return _favoriteProductAdapter.Adapt(returnedProduct);
        }

    }
}
