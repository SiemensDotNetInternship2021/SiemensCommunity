using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAsync();
    }
}
