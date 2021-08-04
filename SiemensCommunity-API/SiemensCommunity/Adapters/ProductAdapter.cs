using AutoMapper;
using SiemensCommunity.Models;
using System.Collections.Generic;

namespace SiemensCommunity.Adapters
{
    public class ProductAdapter
    {
        private readonly IMapper _productAdapter;

        public ProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Photo, Service.Models.Photo>();
                config.CreateMap<Service.Models.Photo, Photo>();
                config.CreateMap<Product, Service.Models.Product>()
                    .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Photo));
                config.CreateMap<Service.Models.Product, Product>()
                    .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Photo));
            });

            _productAdapter = config.CreateMapper();
        }

        public Service.Models.Product Adapt(Product product)
        {
            return _productAdapter.Map<Product, Service.Models.Product>(product);
        }

        public Product Adapt(Service.Models.Product product)
        {
            return _productAdapter.Map<Service.Models.Product, Product>(product);
        }

        public IEnumerable<Product> AdaptList(IEnumerable<Service.Models.Product> products)
        {
            return _productAdapter.Map<IEnumerable<Service.Models.Product>, IEnumerable<Product>>(products);
        }
    }
}
