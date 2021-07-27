using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductService 
    {
        public Task<Product> AddAsync(Product product);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<IEnumerable<Product>> GetAsync();
        public Task<List<ProductDTO>> GetFiltredProducts(int selectedCategory, int selectedOption);
    }
}
