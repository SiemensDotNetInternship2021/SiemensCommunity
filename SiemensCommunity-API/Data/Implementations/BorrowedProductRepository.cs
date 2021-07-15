using Data.Contracts;
using Data.Models;

namespace Data.Implementations
{
    public class BorrowedProductRepository : GenericRepository<BorrowedProduct>, IBorrowedProductRepository
    {
        public BorrowedProductRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
