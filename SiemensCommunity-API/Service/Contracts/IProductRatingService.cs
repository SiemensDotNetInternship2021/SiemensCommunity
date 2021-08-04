using Service.Models;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductRatingService
    {
        public Task<ProductRating> AddWithCheck(ProductRating productDetails);
    }
}
