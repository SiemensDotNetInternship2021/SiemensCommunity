using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IFavoriteProductRepository _favoriteProductRepository;
        private readonly FavoriteProductAdapter _favoriteProductAdapter = new FavoriteProductAdapter();
        private readonly FavoriteProductDTOAdapter _favoriteProductDTOAdapter = new FavoriteProductDTOAdapter();

        public FavoriteProductService(IFavoriteProductRepository departmentRepository)
        {
            _favoriteProductRepository = departmentRepository;
        }

        public async Task<IEnumerable<FavoriteProductDTO>> GetAsync(int userId, int selectedCategory, int selectedOption)
        {
            var returnedFavoriteProducts = await _favoriteProductRepository.GetAsync(userId, selectedCategory, selectedOption);
            return _favoriteProductDTOAdapter.AdaptList(returnedFavoriteProducts);
        }

        public async Task<FavoriteProduct> AddAsync(FavoriteProduct productDetails)
        {
            var returnedProduct = await _favoriteProductRepository.AddAsync(_favoriteProductAdapter.Adapt(productDetails));
            return _favoriteProductAdapter.Adapt(returnedProduct);
        }

        public async Task<FavoriteProduct> DeleteAsync(FavoriteProduct productDetails)
        {
            var returnedProduct = await _favoriteProductRepository.DeleteAsync(_favoriteProductAdapter.Adapt(productDetails));
            return _favoriteProductAdapter.Adapt(returnedProduct);
        }

    }
}
