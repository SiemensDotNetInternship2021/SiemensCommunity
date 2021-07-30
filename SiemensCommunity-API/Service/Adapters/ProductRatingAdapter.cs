using AutoMapper;
using Service.Models;
using System.Collections.Generic;

namespace Service.Adapters
{
    public class ProductRatingAdapter
    {
        private readonly IMapper _productRatingAdapter;

        public ProductRatingAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductRating, Data.Models.ProductRating>();
                config.CreateMap<Data.Models.ProductRating, ProductRating>();
            });

            _productRatingAdapter = config.CreateMapper();
        }

        public Data.Models.ProductRating Adapt(ProductRating productRating)
        {
            return _productRatingAdapter.Map<ProductRating, Data.Models.ProductRating>(productRating);
        }

        public ProductRating Adapt(Data.Models.ProductRating productRating)
        {
            return _productRatingAdapter.Map<Data.Models.ProductRating, ProductRating>(productRating);
        }

        public IEnumerable<ProductRating> AdaptList(IEnumerable<Data.Models.ProductRating> productRatings)
        {
            return _productRatingAdapter.Map<IEnumerable<Data.Models.ProductRating>, IEnumerable<ProductRating>>(productRatings);
        }
    }
}
