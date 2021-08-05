using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductService 
    {
        public Task<Product> AddAsync(AddProduct product);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<IEnumerable<Product>> GetAsync();
        public Task<ProductFormDTO> GetByIdAsync(int id);
        public Task<Product> UpdateAsync(UpdateProductDTO product);
        public Task<List<ProductDTO>> GetFiltredProducts(int selectedCategory, int selectedOption);
        public Task<List<ProductDTO>> GetUserProductsAsync(int userId, int? selectedCategoryId);
        public Task<List<ProductDTO>> GetUserAvailableProductsAsync(int userId, int? selectedCategory);
        public Task<List<ProductDTO>> GetUserLentedProductsAsync(int userId, int? selectedCategory);
    }
}
