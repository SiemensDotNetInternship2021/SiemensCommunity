using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails)
        { 
            await Context.AddAsync(borrowDetails);
            
            var product = Context.Products.SingleOrDefault(p => p.Id == borrowDetails.ProductId);

            product.IsAvailable = false;

            await Context.SaveChangesAsync();

            return borrowDetails;
        }


        public async Task<IEnumerable<BorrowedProduct>> GetBorrowedProductsByUserIdAsync(int userId)
        {
            var returnedBorrowedProducts = await Context.BorrowedProducts.Where(bp => bp.UserId == userId).ToListAsync();

            return returnedBorrowedProducts;
        }


        public async Task<BorrowedProduct> GiveBackProduct(BorrowedProduct borrowDetails)
        {
            var borrowedProduct = await Context.BorrowedProducts.SingleOrDefaultAsync(bp => bp.ProductId == borrowDetails.ProductId && bp.UserId == borrowDetails.UserId);

            Context.BorrowedProducts.Remove(borrowedProduct);

            var product = await Context.Products.SingleOrDefaultAsync(pr => pr.Id == borrowDetails.ProductId);

            product.IsAvailable = true;

            await Context.SaveChangesAsync();

            return borrowedProduct;
        }
    }
}
