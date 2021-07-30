using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductRatingService : IProductRatingService
    {
        private readonly IProductRatingRepository _productRatingRepository;
        private readonly ProductRatingAdapter _productRatingAdapter = new ProductRatingAdapter();

        public ProductRatingService(IProductRatingRepository productRepository)
        {
            _productRatingRepository = productRepository;
        }

        public async Task<ProductRating> AddWithCheck(ProductRating ratingDetails)
        {
            var productRating = await _productRatingRepository.AddWithCheck(_productRatingAdapter.Adapt(ratingDetails));
            return _productRatingAdapter.Adapt(productRating);
        }
    }
}
