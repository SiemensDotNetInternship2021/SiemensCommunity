using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class BorrowedProductService : IBorrowedProductService
    {
        private readonly IBorrowedProductRepository _borrowedProductRepository;
        private readonly BorrowedProductAdapter _borrowedProductAdapter = new BorrowedProductAdapter();

        public BorrowedProductService(IBorrowedProductRepository borrowedProductRepository)
        {
            _borrowedProductRepository = borrowedProductRepository;
        }

        public async Task<IEnumerable<BorrowedProduct>> GetAsync()
        {
            var returnedProducts = await _borrowedProductRepository.GetAsync();
            return _borrowedProductAdapter.AdaptList(returnedProducts);
        }

    }
}
