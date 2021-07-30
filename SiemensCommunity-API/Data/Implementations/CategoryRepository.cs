using Data.Contracts;
using Data.Models;

namespace Data.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
