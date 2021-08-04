using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPropertyService
    {
        public Task<IEnumerable<Property>> GetCategoryProperties(int categoryId);
    }
}
