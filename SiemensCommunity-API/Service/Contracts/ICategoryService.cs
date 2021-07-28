using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        public Task<Category> AddAsync(Category category);
        public Task<IEnumerable<Category>> GetAsync();
    }
}
