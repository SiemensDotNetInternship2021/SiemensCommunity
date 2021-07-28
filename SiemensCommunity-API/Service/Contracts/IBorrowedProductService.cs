using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBorrowedProductService
    {
        public Task<IEnumerable<BorrowedProduct>> GetAsync();
        public Task<IEnumerable<BorrowedProduct>> GetByCategoryIdAsync(int categoryId);
    }
}
