using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class FavoriteProductAdapter
    {
        private readonly IMapper _favoriteProductAdapter;

        public FavoriteProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<FavoriteProduct, Data.Models.FavoriteProduct>();
                config.CreateMap<Data.Models.FavoriteProduct, FavoriteProduct>();
            });

            _favoriteProductAdapter = config.CreateMapper();
        }

        public Data.Models.FavoriteProduct Adapt(FavoriteProduct favoriteProduct)
        {
            return _favoriteProductAdapter.Map<FavoriteProduct, Data.Models.FavoriteProduct>(favoriteProduct);
        }

        public FavoriteProduct Adapt(Data.Models.FavoriteProduct favoriteProduct)
        {
            return _favoriteProductAdapter.Map<Data.Models.FavoriteProduct, FavoriteProduct>(favoriteProduct);
        }

        public IEnumerable<FavoriteProduct> AdaptList(IEnumerable<Data.Models.FavoriteProduct> favoriteProduct)
        {
            return _favoriteProductAdapter.Map<IEnumerable<Data.Models.FavoriteProduct>, IEnumerable<FavoriteProduct>>(favoriteProduct);
        }
    }
}
