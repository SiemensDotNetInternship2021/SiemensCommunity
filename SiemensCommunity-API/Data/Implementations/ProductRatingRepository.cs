using Data.Contracts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class ProductRatingRepository : GenericRepository<ProductRating>, IProductRatingRepository
    {
        public ProductRatingRepository(ProjectDbContext context) : base(context)
        {

        }

        public async Task<ProductRating> AddWithCheck(ProductRating ratingDetails)
        {
            var product = Context.ProductRatings.SingleOrDefault(pr => pr.ProductId == ratingDetails.ProductId && pr.UserId == ratingDetails.UserId);
            if(product != null)
            {
                product.Rate = ratingDetails.Rate;
                await Context.SaveChangesAsync();
                return ratingDetails;

            }
            else
            {
                Context.Add(ratingDetails);
                await Context.SaveChangesAsync();
                return ratingDetails;
            }
        }
    }
}
