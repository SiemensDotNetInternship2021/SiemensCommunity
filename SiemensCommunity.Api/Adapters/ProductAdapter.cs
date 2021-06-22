using AutoMapper;
using SiemensCommunity.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Api.Adapters
{
    public class ProductAdapter
    {
        private readonly IMapper _productAdapter;

        public ProductAdapter()
        {
            var config = new MapperConfiguration(config => {
                config.CreateMap<Product, Services.Models.Entities.Product>();
                config.CreateMap<Services.Models.Entities.Product, Product>();  
                });

            _productAdapter = config.CreateMapper();
        }

        public Services.Models.Entities.Product AdaptProduct(Product product)
        {
            return _productAdapter.Map<Product, Services.Models.Entities.Product>(product);
        }

        public Product AdaptProduct(Services.Models.Entities.Product product)
        {
            return _productAdapter.Map<Services.Models.Entities.Product, Product>(product);
        }
    }
}
