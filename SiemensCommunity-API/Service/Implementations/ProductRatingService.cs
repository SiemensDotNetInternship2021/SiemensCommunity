using Common;
using Data.Contracts;
using Microsoft.Extensions.Logging;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductRatingService : IProductRatingService
    {
        private readonly IProductRatingRepository _productRatingRepository;
        private readonly ProductRatingAdapter _productRatingAdapter = new ProductRatingAdapter();
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly ILogService _logService;

        public ProductRatingService(IProductRatingRepository productRepository, Microsoft.Extensions.Logging.ILoggerFactory logger, ILogService logService)
        {
            _productRatingRepository = productRepository;
            _logService = logService;
            _logger = logger.CreateLogger("ProductRatingService");
        }

        public async Task<ProductRating> AddWithCheck(ProductRating ratingDetails)
        {
            ProductRating product = new ProductRating();
            try
            {
                var productRating = await _productRatingRepository.AddWithCheck(_productRatingAdapter.Adapt(ratingDetails));
                product = _productRatingAdapter.Adapt(productRating);
                _logger.LogInformation(MyLogEvents.RateProduct, "Rate successfully added");
            }
            catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.UpdateUser, "Error while rating the product with message " + ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.InsertItem, ex.Message, ex.StackTrace);
            }
            return product;
        }
    }
}
