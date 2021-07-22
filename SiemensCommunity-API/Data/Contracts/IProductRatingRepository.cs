using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductRatingRepository : IGenericRepository<ProductRating>
    {
        public Task<ProductRating> AddWithCheck(ProductRating productDetails);
    }
}
