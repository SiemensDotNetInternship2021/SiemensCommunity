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
    }
}
