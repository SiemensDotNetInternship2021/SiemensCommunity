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
            //    products.Where(x => x.CategoryId == categoryId && borrowedProducts.Any(rp => rp.ProductId == x.Id));

            return _borrowedProductAdapter.AdaptList(filteredProducts);
        }

    }
}
