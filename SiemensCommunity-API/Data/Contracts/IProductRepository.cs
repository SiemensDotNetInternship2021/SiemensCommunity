using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<ProductDTO>> GetFiltredProducts(int selectedCategory, int selectedOption);
        public Task<ProductFormDTO> FindById(int id);
    }
}
