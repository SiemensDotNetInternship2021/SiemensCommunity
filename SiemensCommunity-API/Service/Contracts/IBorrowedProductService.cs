using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBorrowedProductService
    {
        public Task<IEnumerable<BorrowedProduct>> GetAsync();

        public Task<IEnumerable<BorrowedProductDTO>> GetByCategoryIdAsync(int userId, int categoryId);

        public Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails);

        public Task<IEnumerable<BorrowedProductDTO>> GetBorrowedByUserIdAsync(int userId);

        public Task<BorrowedProduct> ReturnBorrowedProduct(BorrowedProduct borrowDetails);

        public Task<IEnumerable<BorrowedProductDTO>> GetBorrowedAsync(int userId);
    }
}
