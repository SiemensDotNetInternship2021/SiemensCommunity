using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IBorrowedProductRepository : IGenericRepository<BorrowedProduct>
    {
        public Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails);

        public Task<IEnumerable<BorrowedProduct>> GetBorrowedProductsByUserIdAsync(int userId);

        public Task<BorrowedProduct> GiveBackProduct(BorrowedProduct borrowDetails);
    }
}
