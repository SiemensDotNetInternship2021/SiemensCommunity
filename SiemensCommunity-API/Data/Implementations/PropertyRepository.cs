using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ProjectDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Property>> GetCategoryProperties(int categoryId)
        {
            var properties = await Context.Properties.Where(p => p.CategoryId == categoryId).ToListAsync();
            return properties;
        }
    }
}
