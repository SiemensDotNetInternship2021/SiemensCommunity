using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository 
    {
        public DepartmentRepository(ProjectDbContext context) : base(context)
        {
            
        }

       /* public async Task<IEnumerable<Department>> GetAsync()
        {
            return await Context.Departments.ToListAsync();
        }*/
    }
}
