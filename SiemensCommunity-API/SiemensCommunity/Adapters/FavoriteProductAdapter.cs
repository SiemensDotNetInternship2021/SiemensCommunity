using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class FavoriteProductAdapter
    {
        private readonly IMapper _favoriteProductAdapter;

        public FavoriteProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<FavoriteProduct, Service.Models.FavoriteProduct>();
                config.CreateMap<Service.Models.FavoriteProduct, FavoriteProduct>();
            });

            _favoriteProductAdapter = config.CreateMapper();
        }

        public Service.Models.FavoriteProduct Adapt(FavoriteProduct favoriteProduct)
        {
            return _favoriteProductAdapter.Map<FavoriteProduct, Service.Models.FavoriteProduct>(favoriteProduct);
        }

        public FavoriteProduct Adapt(Service.Models.FavoriteProduct favoriteProduct)
        {
            return _favoriteProductAdapter.Map<Service.Models.FavoriteProduct, FavoriteProduct>(favoriteProduct);
        }

        public IEnumerable<FavoriteProduct> AdaptList(IEnumerable<Service.Models.FavoriteProduct> favoriteProduct)
        {
            return _favoriteProductAdapter.Map<IEnumerable<Service.Models.FavoriteProduct>, IEnumerable<FavoriteProduct>>(favoriteProduct);
        }
    }
}
