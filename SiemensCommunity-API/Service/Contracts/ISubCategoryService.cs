using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubCategoryService
    {
        public Task<IEnumerable<SubCategory>> GetAsync();
    }
}
