using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class BorrowedProductAdapter
    {
        private readonly IMapper _borrowedProductAdapter;

        public BorrowedProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<BorrowedProduct, Service.Models.BorrowedProduct>();
                config.CreateMap<Service.Models.BorrowedProduct, BorrowedProduct>();
            });

            _borrowedProductAdapter = config.CreateMapper();
        }

        public Service.Models.BorrowedProduct Adapt(BorrowedProduct borrowedProduct)
        {
            return _borrowedProductAdapter.Map<BorrowedProduct, Service.Models.BorrowedProduct>(borrowedProduct);
        }

        public BorrowedProduct Adapt(Service.Models.BorrowedProduct borrowedProduct)
        {
            return _borrowedProductAdapter.Map<Service.Models.BorrowedProduct, BorrowedProduct>(borrowedProduct);
        }

        public IEnumerable<BorrowedProduct> AdaptList(IEnumerable<Service.Models.BorrowedProduct> borrowedProducts)
        {
            return _borrowedProductAdapter.Map<IEnumerable<Service.Models.BorrowedProduct>, IEnumerable<BorrowedProduct>>(borrowedProducts);
        }
    }
}
