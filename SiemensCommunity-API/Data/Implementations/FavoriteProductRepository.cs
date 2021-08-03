using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class FavoriteProductRepository : GenericRepository<FavoriteProduct>, IFavoriteProductRepository
    {
        public FavoriteProductRepository(ProjectDbContext context) : base(context)
        {


        }

        public async Task<IEnumerable<FavoriteProductDTO>> GetAsync(int userId, int selectedCategory, int selectedOption)
        {
          
            if (selectedOption == 2 && selectedCategory == 0)
            {
                var favoriteProduct = Context.FavoriteProducts.Where(fp => fp.UserId == userId).Include(fp => fp.Product).Include(fp => fp.Photo).Select(
                x => new FavoriteProductDTO
                {
                    Id = x.ProductId.Value,
                    Details = x.Product.Details,
                    IsAvailable = x.Product.IsAvailable,
                    Name = x.Product.Name,
                    Rating = Math.Round(x.Product.ProductRating.Where(pr => pr.ProductId == x.ProductId).Select(pr => (int?)pr.Rate).Average() ?? 0.0, 2),
                    User = x.Product.User.UserName,
                    CategoryName = x.Product.Category.Name,
                    SubCategoryName = x.Product.SubCategory.Name,
                    ImagePath = x.Product.Photo.Url
                }) ;
                return await favoriteProduct.ToListAsync();
            }
            else if (selectedOption == 2 && (selectedCategory == 1 || selectedCategory == 2))
            {
                var favoriteProduct = Context.FavoriteProducts.Where(fp => fp.UserId == userId).Include(fp => fp.Product).Include(fp => fp.Photo).Where(fp => fp.Product.Id == fp.ProductId).Where(fp => fp.Product.CategoryId == selectedCategory).Select(
                x => new FavoriteProductDTO
                {
                    Id = x.ProductId.Value,
                    Details = x.Product.Details,
                    IsAvailable = x.Product.IsAvailable,
                    Name = x.Product.Name,
                    Rating = Math.Round(x.Product.ProductRating.Where(pr => pr.ProductId == x.ProductId).Select(pr => (int?)pr.Rate).Average() ?? 0.0, 2),
                    User = x.Product.User.UserName,
                    CategoryName = x.Product.Category.Name,
                    SubCategoryName = x.Product.SubCategory.Name,
                    ImagePath = x.Product.Photo.Url
                });
                return await favoriteProduct.ToListAsync();
            }
            else
            { 
                return null;
            }
        }

        public async Task<FavoriteProduct> DeleteAsync(FavoriteProduct productDetails)
        {
            var productToDelete = Context.FavoriteProducts.Where(fp => fp.ProductId == productDetails.ProductId && fp.UserId == productDetails.UserId)
                .First();
            Context.FavoriteProducts.Remove(productToDelete);
            var saveChanges = await Context.SaveChangesAsync();
            return productDetails;
        }
    }
}

