using AutoMapper;
using Service.Models;
using System.Collections.Generic;

namespace Service.Adapters
{
    public class BorrowedProductAdapter
    {
        private readonly IMapper _borrowedProductAdapter;

        public BorrowedProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<BorrowedProduct, Data.Models.BorrowedProduct>();
                config.CreateMap<Data.Models.BorrowedProduct, BorrowedProduct>();
            });

            _borrowedProductAdapter = config.CreateMapper();
        }

        public Data.Models.BorrowedProduct Adapt(BorrowedProduct borrowedProduct)
        {
            return _borrowedProductAdapter.Map<BorrowedProduct, Data.Models.BorrowedProduct>(borrowedProduct);
        }

        public BorrowedProduct Adapt(Data.Models.BorrowedProduct borrowedProduct)
        {
            return _borrowedProductAdapter.Map<Data.Models.BorrowedProduct, BorrowedProduct>(borrowedProduct);
        }

        public IEnumerable<BorrowedProduct> AdaptList(IEnumerable<Data.Models.BorrowedProduct> borrowedProducts)
        {
            return _borrowedProductAdapter.Map<IEnumerable<Data.Models.BorrowedProduct>, IEnumerable<BorrowedProduct>>(borrowedProducts);
        }
    }
}
