using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class FavoriteProductRepository : GenericRepository<FavoriteProduct>, IFavoriteProductRepository
    {
        public FavoriteProductRepository(ProjectDbContext context) : base(context)
        {


        }

        public async Task<IEnumerable<FavoriteProduct>> GetAsync(int userId)
        {
            var favoriteProduct = Context.FavoriteProducts.Where(fp => fp.UserId == userId).Select(fp => new FavoriteProduct
            {
                Id = fp.Id,
                ProductId = fp.ProductId,
                UserId = fp.UserId,
            });
            return await favoriteProduct.ToListAsync();
        }
    }
}

