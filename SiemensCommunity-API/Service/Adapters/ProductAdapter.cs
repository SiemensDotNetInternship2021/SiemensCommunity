using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class ProductAdapter
    {
        private readonly IMapper _productAdapter;

        public ProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Photo, Data.Models.Photo>();
                config.CreateMap<Data.Models.Photo, Photo>();
                config.CreateMap<Product, Data.Models.Product>()
                    .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Photo));
                config.CreateMap<Data.Models.Product, Product>()
                    .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Photo));
                config.CreateMap<Data.Models.Product, AddProduct>();
                config.CreateMap<AddProduct, Data.Models.Product>();
            });

            _productAdapter = config.CreateMapper();
        }

        public Data.Models.Product Adapt(Product product)
        {
            return _productAdapter.Map<Product, Data.Models.Product>(product);
        }

        public Product Adapt(Data.Models.Product product)
        {
            return _productAdapter.Map<Data.Models.Product, Product>(product);
        }
        public Data.Models.Product AdaptAddProductToProduct(AddProduct product)
        {
            var result = _productAdapter.Map<AddProduct, Data.Models.Product>(product);
            return result;
        }

        public IEnumerable<Product> AdaptList(IEnumerable<Data.Models.Product> products)
        {
            return _productAdapter.Map<IEnumerable<Data.Models.Product>, IEnumerable<Product>>(products);
        }
    }
}

