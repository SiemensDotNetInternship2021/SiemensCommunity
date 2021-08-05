using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class BorrowedProductService : IBorrowedProductService
    {
        private readonly IBorrowedProductRepository _borrowedProductRepository;
        private readonly IProductRepository _productRepository;

        private readonly BorrowedProductAdapter _borrowedProductAdapter = new BorrowedProductAdapter();

        public BorrowedProductService(IBorrowedProductRepository borrowedProductRepository, IProductRepository productRepository)
        {
            _borrowedProductRepository = borrowedProductRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<BorrowedProduct>> GetAsync()
        {
            var returnedProducts = await _borrowedProductRepository.GetAsync();
            return _borrowedProductAdapter.AdaptList(returnedProducts);
        }

        public async Task<IEnumerable<BorrowedProduct>> GetByCategoryIdAsync(int categoryId)
        {
            var borrowedProducts = await _borrowedProductRepository.GetAsync();
            var products = await _productRepository.GetAsync();
            var filteredProducts = borrowedProducts.Where(x => products.Any(p => p.Id == x.ProductId && p.CategoryId == categoryId));
            return _borrowedProductAdapter.AdaptList(filteredProducts); 
        }

        public async Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails)
        {
            var borrowedProduct = await _borrowedProductRepository.BorrowProduct(_borrowedProductAdapter.Adapt(borrowDetails));
            return _borrowedProductAdapter.Adapt(borrowedProduct);
        }

        public async Task<IEnumerable<BorrowedProduct>> GetBorrowedByUserIdAsync(int userId)
        {
            var borrowedProduct = await _borrowedProductRepository.GetBorrowedProductsByUserIdAsync(userId);
            return _borrowedProductAdapter.AdaptList(borrowedProduct);
        }

        public async Task<BorrowedProduct> ReturnBorrowedProduct(BorrowedProduct borrowDetails)
        {
            var returnedProduct = await _borrowedProductRepository.GiveBackProduct(_borrowedProductAdapter.Adapt(borrowDetails));
            return _borrowedProductAdapter.Adapt(returnedProduct);
        }
    }
}
