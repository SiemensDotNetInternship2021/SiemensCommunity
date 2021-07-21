using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class AddProductAdapter
    {
        private readonly IMapper _addProductAdapter;

        public AddProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<AddProduct, Service.Models.AddProduct>()
                .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Files[0]));
                config.CreateMap<Service.Models.Product, AddProduct>();
            });

            _addProductAdapter = config.CreateMapper();
        }

        public Service.Models.AddProduct Adapt(AddProduct product)
        {
            return _addProductAdapter.Map<AddProduct, Service.Models.AddProduct>(product);
        }

        public AddProduct Adapt(Service.Models.AddProduct product)
        {
            return _addProductAdapter.Map<Service.Models.AddProduct, AddProduct>(product);
        }

    }
}
