using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class FavoriteProductService : IFavoriteProductService
    {
        private readonly IFavoriteProductRepository _favoriteProductRepository;
        private readonly FavoriteProductAdapter _favoriteProductAdapter = new FavoriteProductAdapter();

        public FavoriteProductService(IFavoriteProductRepository departmentRepository)
        {
            _favoriteProductRepository = departmentRepository;
        }

        public async Task<IEnumerable<FavoriteProduct>> GetAsync(int userId)
        {
            var returnedFavoriteProducts = await _favoriteProductRepository.GetAsync(userId);
            return _favoriteProductAdapter.AdaptList(returnedFavoriteProducts);
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
