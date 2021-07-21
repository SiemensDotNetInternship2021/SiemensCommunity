using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductService 
    {
        public Task<Product> AddAsync(AddProduct product);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<IEnumerable<Product>> GetAsync();
        public Task<ProductFormDTO> GetByIdAsync(int id); 
    }
}
