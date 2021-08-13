using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class BorrowedProductDTOAdapter
    {
        private readonly IMapper _borrowedProductDTOAdapter;

        public BorrowedProductDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<BorrowedProductDTO, Data.Models.BorrowedProductDTO>();
                config.CreateMap<Data.Models.BorrowedProductDTO, BorrowedProductDTO>();
            });

            _borrowedProductDTOAdapter = config.CreateMapper();
        }

        public Data.Models.BorrowedProductDTO Adapt(BorrowedProductDTO borrowedProduct)
        {
            return _borrowedProductDTOAdapter.Map<BorrowedProductDTO, Data.Models.BorrowedProductDTO>(borrowedProduct);
        }

        public BorrowedProductDTO Adapt(Data.Models.BorrowedProductDTO borrowedProduct)
        {
            return _borrowedProductDTOAdapter.Map<Data.Models.BorrowedProductDTO, BorrowedProductDTO>(borrowedProduct);
        }

        public IEnumerable<BorrowedProductDTO> AdaptEnumerable(IEnumerable<Data.Models.BorrowedProductDTO> borrowedProducts)
        {
            return _borrowedProductDTOAdapter.Map<IEnumerable<Data.Models.BorrowedProductDTO>, IEnumerable<BorrowedProductDTO>>(borrowedProducts);
        }
        public IEnumerable<Data.Models.BorrowedProductDTO>  AdaptEnumerable(IEnumerable<BorrowedProductDTO> borrowedProducts)
        {
            return _borrowedProductDTOAdapter.Map<IEnumerable<BorrowedProductDTO>, IEnumerable<Data.Models.BorrowedProductDTO>>(borrowedProducts);
        }
    }
}
