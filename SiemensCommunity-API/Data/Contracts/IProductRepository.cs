using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<ProductDTO>> GetFiltredProducts(int selectedCategory, int selectedOption);
        public Task<ProductFormDTO> FindById(int id);
        public Task<List<ProductDTO>> GetUserProductsAsync(int userId);
        public Task<List<ProductDTO>> GetUserProductsByCategoryAsync(int userId, int categoryId);
        public Task<List<ProductDTO>> GetUserAvailableProductsAsync(int userId);
        public Task<List<ProductDTO>> GetUserAvailableProductsByCategoryAsync(int userId, int categoryId);
        public Task<List<ProductDTO>> GetUserLentedProductsAsync(int userId);
        public Task<List<ProductDTO>> GetUserLentedProductsByCategoryAsync(int userId, int categoryId);
    }
}
