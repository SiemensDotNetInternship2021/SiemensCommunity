using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IFavoriteProductRepository : IGenericRepository<FavoriteProduct>
    {
        public Task<IEnumerable<FavoriteProductDTO>> GetAsync(int userId, int selectedCategory, int selectedOption);

        public Task<FavoriteProduct> DeleteAsync(FavoriteProduct productDetails);
    }
}
