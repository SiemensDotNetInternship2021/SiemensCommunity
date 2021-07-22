using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class UpdateProductAdapter
    {
        private readonly IMapper _updateProductAdapter;
        public UpdateProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UpdateProductDTO, Service.Models.UpdateProductDTO>()
                .ForMember(dest => dest.File, act => act.MapFrom(src => src.Files[0]));
                config.CreateMap<Service.Models.UpdateProductDTO, UpdateProductDTO>();
            });

            _updateProductAdapter = config.CreateMapper();
        }

        public Service.Models.UpdateProductDTO Adapt(UpdateProductDTO product)
        {
            return _updateProductAdapter.Map<UpdateProductDTO, Service.Models.UpdateProductDTO>(product);
        }

        public UpdateProductDTO Adapt(Service.Models.UpdateProductDTO product)
        {
            return _updateProductAdapter.Map<Service.Models.UpdateProductDTO, UpdateProductDTO>(product);
        }
    }
}
