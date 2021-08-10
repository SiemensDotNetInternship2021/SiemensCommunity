using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class BorrowedProductService : IBorrowedProductService
    {
        private readonly IBorrowedProductRepository _borrowedProductRepository;
        private readonly IProductRepository _productRepository;

        private readonly ProductDTOAdapter productDTOAdapter = new ProductDTOAdapter();
        private readonly BorrowedProductAdapter _borrowedProductAdapter = new BorrowedProductAdapter();
        private readonly BorrowedProductDTOAdapter _borrowedProductDTOAdapter = new BorrowedProductDTOAdapter();

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

        public async Task<IEnumerable<ProductDTO>> GetByCategoryIdAsync(int userId, int categoryId)
        {
            var borrowedProducts = await _borrowedProductRepository.GetBorrowedProductsOfUserByCategoryIdAsync(userId, categoryId);
            return productDTOAdapter.AdaptEnumerable(borrowedProducts);
        }

        public async Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails)
        {
            var borrowedProduct = await _borrowedProductRepository.BorrowProduct(_borrowedProductAdapter.Adapt(borrowDetails));
            return _borrowedProductAdapter.Adapt(borrowedProduct);
        }

        public async Task<IEnumerable<ProductDTO>> GetBorrowedByUserIdAsync(int userId)
        {
            var borrowedProduct = await _borrowedProductRepository.GetBorrowedProductsByUserIdAsync(userId);
            return productDTOAdapter.AdaptEnumerable(borrowedProduct);
        }

        public async Task<BorrowedProduct> ReturnBorrowedProduct(BorrowedProduct borrowDetails)
        {
            var adat = _borrowedProductAdapter.Adapt(borrowDetails);
            var returnedProduct = await _borrowedProductRepository.GiveBackProduct(adat);
            return _borrowedProductAdapter.Adapt(returnedProduct);
        }

        public async Task<IEnumerable<ProductDTO>> GetBorrowedAsync(int userId)
        {
            IEnumerable<Data.Models.ProductDTO> returnedFavoriteProducts = new List<Data.Models.ProductDTO>();
            try
            {
                returnedFavoriteProducts = await _borrowedProductRepository.GetBorrowedProductsByUserIdAsync(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return productDTOAdapter.AdaptEnumerable(returnedFavoriteProducts);
        }
    }
}
