using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class ProductDTOAdapter
    {
        private readonly IMapper _productAdapter;

        public ProductDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Service.Models.ProductDTO>();
                config.CreateMap<Service.Models.ProductDTO, ProductDTO>();
            });

            _productAdapter = config.CreateMapper();
        }

        public Service.Models.ProductDTO Adapt(ProductDTO product)
        {
            return _productAdapter.Map<ProductDTO, Service.Models.ProductDTO>(product);
        }

        public ProductDTO Adapt(Service.Models.ProductDTO product)
        {
            return _productAdapter.Map<Service.Models.ProductDTO, ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> AdaptList(IEnumerable<Service.Models.ProductDTO> products)
        {
            return _productAdapter.Map<IEnumerable<Service.Models.ProductDTO>, IEnumerable<ProductDTO>>(products);
        }
    }
}
