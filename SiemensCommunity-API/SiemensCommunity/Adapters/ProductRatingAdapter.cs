using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class ProductRatingAdapter
    {
        private readonly IMapper _productRatingAdapter;

        public ProductRatingAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductRating, Service.Models.ProductRating>();
                config.CreateMap<Service.Models.ProductRating, ProductRating>();
            });

            _productRatingAdapter = config.CreateMapper();
        }

        public Service.Models.ProductRating Adapt(ProductRating productRating)
        {
            return _productRatingAdapter.Map<ProductRating, Service.Models.ProductRating>(productRating);
        }

        public ProductRating Adapt(Service.Models.ProductRating productRating)
        {
            return _productRatingAdapter.Map<Service.Models.ProductRating, ProductRating>(productRating);
        }

        public IEnumerable<ProductRating> AdaptList(IEnumerable<Service.Models.ProductRating> productRatings)
        {
            return _productRatingAdapter.Map<IEnumerable<Service.Models.ProductRating>, IEnumerable<ProductRating>>(productRatings);
        }
    }
}
