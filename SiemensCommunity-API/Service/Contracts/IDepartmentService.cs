using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetAsync();
    }
}
