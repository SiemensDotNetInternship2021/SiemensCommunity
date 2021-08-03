using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class UpdateProductAdapter
    {
        private readonly IMapper _updateProductAdapter;

        public UpdateProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {

                config.CreateMap<UpdateProductDTO, Data.Models.Product>()
                .ForMember(dest => dest.RatingAverage, opt => opt.Ignore())
                .ForMember(dest => dest.IsAvailable, opt => opt.Ignore());
                config.CreateMap<Data.Models.Product, UpdateProductDTO>();
            });

            _updateProductAdapter = config.CreateMapper();
        }

        public Data.Models.Product Adapt(UpdateProductDTO product)
        {
            return _updateProductAdapter.Map<UpdateProductDTO, Data.Models.Product>(product);
        }

        public UpdateProductDTO Adapt(Data.Models.Product product)
        {
            return _updateProductAdapter.Map<Data.Models.Product, UpdateProductDTO>(product);
        }
    }
}
