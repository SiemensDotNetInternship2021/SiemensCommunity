using Data.Contracts;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class BorrowedProductRepository : GenericRepository<BorrowedProduct>, IBorrowedProductRepository
    {
        public BorrowedProductRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
