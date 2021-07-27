using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IFavoriteProductRepository : IGenericRepository<FavoriteProduct>
    {
        public Task<IEnumerable<FavoriteProductDTO>> GetAsync(int userId, int selectedCategory, int selectedOption);

        public Task<FavoriteProduct> DeleteAsync(FavoriteProduct productDetails);
    }
}
