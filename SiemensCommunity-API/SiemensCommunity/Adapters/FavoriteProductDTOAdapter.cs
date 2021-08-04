using AutoMapper;
using SiemensCommunity.Models;
using System.Collections.Generic;

namespace SiemensCommunity.Adapters
{
    public class FavoriteProductDTOAdapter
    {
        private readonly IMapper _favoriteProductDTOAdapter;

        public FavoriteProductDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<FavoriteProductDTO, Service.Models.FavoriteProductDTO>();
                config.CreateMap<Service.Models.FavoriteProductDTO, FavoriteProductDTO>();
            });

            _favoriteProductDTOAdapter = config.CreateMapper();
        }

        public Service.Models.FavoriteProductDTO Adapt(FavoriteProductDTO favoriteProduct)
        {
            return _favoriteProductDTOAdapter.Map<FavoriteProductDTO, Service.Models.FavoriteProductDTO>(favoriteProduct);
        }

        public FavoriteProductDTO Adapt(Service.Models.FavoriteProduct favoriteProduct)
        {
            return _favoriteProductDTOAdapter.Map<Service.Models.FavoriteProduct, FavoriteProductDTO>(favoriteProduct);
        }

        public IEnumerable<FavoriteProductDTO> AdaptList(IEnumerable<Service.Models.FavoriteProductDTO> favoriteProduct)
        {
            return _favoriteProductDTOAdapter.Map<IEnumerable<Service.Models.FavoriteProductDTO>, IEnumerable<FavoriteProductDTO>>(favoriteProduct);
        }
    }
}
