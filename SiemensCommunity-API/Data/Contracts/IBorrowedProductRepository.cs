using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IBorrowedProductRepository : IGenericRepository<BorrowedProduct>
    {
        //public Task<IEnumerable<BorrowedProduct>> GetByCategoryIdAsync(int categoryId);

    }
}
