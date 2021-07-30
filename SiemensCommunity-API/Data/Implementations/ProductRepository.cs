using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProjectDbContext context) : base(context)
        {

        }

        public async Task<List<ProductDTO>> GetFiltredProducts(int selectedCategory, int selectedOption)
        {
            if (selectedOption == 0 && selectedCategory == 0)
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory)
                .Include(pr => pr.ProductRating)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Details = x.Details,
                    IsAvailable = x.IsAvailable,
                    Name = x.Name,
                    Rating = Math.Round(x.ProductRating.Where(pr => pr.ProductId == x.Id).Select(pr => (int?)pr.Rate).Average() ?? 0.0, 2),
                    User = x.User.UserName,
                    CategoryName = x.Category.Name,
                    SubCategoryName = x.SubCategory.Name,
                    ImagePath = x.ImagePath
                }).ToListAsync();

                foreach (var element in await product)
                {
                    var check = Context.Products.SingleOrDefault(pr => pr.Id == element.Id);
                    if (check != null)
                    {
                        check.Rating = element.Rating;
                        await Context.SaveChangesAsync();
                    }
                }

                return await product;
            }
            if (selectedOption == 0 && (selectedCategory == 1 || selectedCategory == 2))
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory).Where(pr => pr.CategoryId == selectedCategory)
               .Include(pr => pr.ProductRating)
               .Select(x => new ProductDTO
               {
                   Id = x.Id,
                   Details = x.Details,
                   IsAvailable = x.IsAvailable,
                   Name = x.Name,
                   Rating = Math.Round(x.ProductRating.Where(pr => pr.ProductId == x.Id).Select(pr => (int?)pr.Rate).Average() ?? 0.0, 2),
                   User = x.User.UserName,
                   CategoryName = x.Category.Name,
                   SubCategoryName = x.SubCategory.Name,
                   ImagePath = x.ImagePath,
               }).ToListAsync();

                foreach (var element in await product)
                {
                    var check = Context.Products.SingleOrDefault(pr => pr.Id == element.Id);
                    if (check != null)
                    {
                        check.Rating = element.Rating;
                        await Context.SaveChangesAsync();
                    }
                }

                return await product;
            }
            if (selectedOption == 1 && (selectedCategory == 0))
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory).Where(pr => pr.IsAvailable == true)
                .Include(pr => pr.ProductRating)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Details = x.Details,
                    IsAvailable = x.IsAvailable,
                    Name = x.Name,
                    Rating = Math.Round(x.ProductRating.Where(pr => pr.ProductId == x.Id).Select(pr => (int?)pr.Rate).Average() ?? 0.0, 2),
                    User = x.User.UserName,
                    CategoryName = x.Category.Name,
                    SubCategoryName = x.SubCategory.Name,
                    ImagePath = x.ImagePath
                }).ToListAsync();

                foreach (var element in await product)
                {
                    var check = Context.Products.SingleOrDefault(pr => pr.Id == element.Id);
                    if (check != null)
                    {
                        check.Rating = element.Rating;
                        await Context.SaveChangesAsync();
                    }
                }

                return await product;
            }
            if (selectedOption == 1 && (selectedCategory == 1 || selectedCategory == 2))
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory).Where(pr => pr.CategoryId == selectedCategory && pr.IsAvailable == true)
                .Include(pr => pr.ProductRating)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Details = x.Details,
                    IsAvailable = x.IsAvailable,
                    Name = x.Name,
                    Rating = Math.Round(x.ProductRating.Where(pr => pr.ProductId == x.Id).Select(pr => (int?)pr.Rate).Average() ?? 0.0, 2),
                    User = x.User.UserName,
                    CategoryName = x.Category.Name,
                    SubCategoryName = x.SubCategory.Name,
                    ImagePath = x.ImagePath
                }).ToListAsync();

                foreach (var element in await product)
                {
                    var check = Context.Products.SingleOrDefault(pr => pr.Id == element.Id);
                    if (check != null)
                    {
                        check.Rating = element.Rating;
                        await Context.SaveChangesAsync();
                    }
                }

                return await product;
            }
            else
            {
                return null;
            }
        } 
    }
}