using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class FavoriteProductDTOAdapter
    {
        private readonly IMapper _favoriteProductDTOAdapter;

        public FavoriteProductDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<FavoriteProductDTO, Data.Models.FavoriteProductDTO>();
                config.CreateMap<Data.Models.FavoriteProductDTO, FavoriteProductDTO>();
            });

            _favoriteProductDTOAdapter = config.CreateMapper();
        }

        public Data.Models.FavoriteProductDTO Adapt(FavoriteProductDTO favoriteProduct)
        {
            return _favoriteProductDTOAdapter.Map<FavoriteProductDTO, Data.Models.FavoriteProductDTO>(favoriteProduct);
        }

        public FavoriteProductDTO Adapt(Data.Models.FavoriteProduct favoriteProduct)
        {
            return _favoriteProductDTOAdapter.Map<Data.Models.FavoriteProduct, FavoriteProductDTO>(favoriteProduct);
        }

        public IEnumerable<FavoriteProductDTO> AdaptList(IEnumerable<Data.Models.FavoriteProductDTO> favoriteProduct)
        {
            return _favoriteProductDTOAdapter.Map<IEnumerable<Data.Models.FavoriteProductDTO>, IEnumerable<FavoriteProductDTO>>(favoriteProduct);
        }
    }
}
