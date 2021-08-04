using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBorrowedProductService
    {
        public Task<IEnumerable<BorrowedProduct>> GetAsync();

        public Task<IEnumerable<BorrowedProduct>> GetByCategoryIdAsync(int categoryId);

        public Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails);

        public Task<IEnumerable<BorrowedProduct>> GetBorrowedByUserIdAsync(int userId);

        public Task<BorrowedProduct> ReturnBorrowedProduct(BorrowedProduct borrowDetails);
    }
}
