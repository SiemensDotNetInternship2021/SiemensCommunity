using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class BorrowedProductDTOAdapter
    {
        private readonly IMapper _borrowedProductDTOAdapter;

        public BorrowedProductDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<BorrowedProductDTO, Service.Models.BorrowedProductDTO>();
                config.CreateMap<Service.Models.BorrowedProductDTO, BorrowedProductDTO>();
            });

            _borrowedProductDTOAdapter = config.CreateMapper();
        }

        public Service.Models.BorrowedProductDTO Adapt(BorrowedProductDTO borrowedProduct)
        {
            return _borrowedProductDTOAdapter.Map<BorrowedProductDTO, Service.Models.BorrowedProductDTO>(borrowedProduct);
        }

        public BorrowedProductDTO Adapt(Service.Models.BorrowedProductDTO borrowedProduct)
        {
            return _borrowedProductDTOAdapter.Map<Service.Models.BorrowedProductDTO, BorrowedProductDTO>(borrowedProduct);
        }

        public IEnumerable<BorrowedProductDTO> AdaptList(IEnumerable<Service.Models.BorrowedProductDTO> borrowedProducts)
        {
            return _borrowedProductDTOAdapter.Map<IEnumerable<Service.Models.BorrowedProductDTO>, IEnumerable<BorrowedProductDTO>>(borrowedProducts);
        }
    }
}
