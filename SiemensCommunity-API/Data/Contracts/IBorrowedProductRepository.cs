using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IBorrowedProductRepository : IGenericRepository<BorrowedProduct>
    {
        public Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails);


        public Task<BorrowedProduct> GiveBackProduct(BorrowedProduct borrowDetails);
        public Task<IEnumerable<BorrowedProductDTO>> GetBorrowedProductsByUserIdAsync(int userId);
        public Task<IEnumerable<BorrowedProductDTO>> GetBorrowedProductsOfUserByCategoryIdAsync(int userId, int categoryId);
    }
}
