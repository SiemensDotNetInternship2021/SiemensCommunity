using Data.Contracts;
using Data.Models;

namespace Data.Implementations
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
