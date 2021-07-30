using Data.Contracts;
using Data.Models;

namespace Data.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository 
    {
        public DepartmentRepository(ProjectDbContext context) : base(context)
        {
            
        }
    }
}
