using Data.Models;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductRatingRepository : IGenericRepository<ProductRating>
    {
        public Task<ProductRating> AddWithCheck(ProductRating productDetails);
    }
}
