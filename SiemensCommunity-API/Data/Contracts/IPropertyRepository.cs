using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPropertyRepository: IGenericRepository<Property>
    {
        public Task<IEnumerable<Property>> GetCategoryProperties(int categoryId);
    }
}
