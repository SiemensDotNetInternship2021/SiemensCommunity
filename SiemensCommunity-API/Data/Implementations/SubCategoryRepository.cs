using Data.Contracts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class SubCategoryRepository: GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ProjectDbContext context): base(context)
        {
        }
    }
}
