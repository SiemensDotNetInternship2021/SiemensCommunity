using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<ProductDTO>> GetProducts(int selectedCategory, int selectedOption);
    }
}
