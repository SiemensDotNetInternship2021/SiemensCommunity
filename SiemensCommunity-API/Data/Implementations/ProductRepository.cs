﻿using Data.Contracts;
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

        public async Task<List<ProductDTO>> GetProducts(int selectedCategory, int selectedOption)
        {
            if (selectedOption == 0 && selectedCategory == 0)
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory)
               .Select(x => new ProductDTO
               {
                   Id = x.Id,
                   Details = x.Details,
                   IsAvailable = x.IsAvailable,
                   Name = x.Name,
                   Rating = x.Rating,
                   User = x.User.UserName,
                   CategoryName = x.Category.Name,
                   SubCategoryName = x.SubCategory.Name,
                   ImagePath = x.ImagePath
               });
                return await product.ToListAsync();
            }
            else
            if (selectedOption == 0 && (selectedCategory == 1 || selectedCategory == 2))
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory).Where(pr => pr.CategoryId == selectedCategory)
               .Select(x => new ProductDTO
               {
                   Id = x.Id,
                   Details = x.Details,
                   IsAvailable = x.IsAvailable,
                   Name = x.Name,
                   Rating = x.Rating,
                   User = x.User.UserName,
                   CategoryName = x.Category.Name,
                   SubCategoryName = x.SubCategory.Name,
                   ImagePath = x.ImagePath
               });
                return await product.ToListAsync();
            }
            else
            if (selectedOption == 1 && (selectedCategory == 0 ))
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory).Where(pr => pr.IsAvailable == true)
                .Select(x => new ProductDTO
                {
                     Id = x.Id,
                     Details = x.Details,
                     IsAvailable = x.IsAvailable,
                     Name = x.Name,
                     Rating = x.Rating,
                     User = x.User.UserName,
                     CategoryName = x.Category.Name,
                     SubCategoryName = x.SubCategory.Name,
                     ImagePath = x.ImagePath
                });
                return await product.ToListAsync();
            }
            else
            if (selectedOption == 1 && (selectedCategory == 1 || selectedCategory == 2))
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory).Where(pr => pr.CategoryId == selectedCategory && pr.IsAvailable == true)
                .Select(x => new ProductDTO
                {
                      Id = x.Id,
                      Details = x.Details,
                      IsAvailable = x.IsAvailable,
                      Name = x.Name,
                      Rating = x.Rating,
                      User = x.User.UserName,
                      CategoryName = x.Category.Name,
                      SubCategoryName = x.SubCategory.Name,
                      ImagePath = x.ImagePath
                });
                return await product.ToListAsync();
            }
            else
            {
                var product = Context.Products.Include(pr => pr.User).Include(pr => pr.Category).Include(pr => pr.SubCategory)
               .Select(x => new ProductDTO
               {
                   Id = x.Id,
                   Details = x.Details,
                   IsAvailable = x.IsAvailable,
                   Name = x.Name,
                   Rating = x.Rating,
                   User = x.User.UserName,
                   CategoryName = x.Category.Name,
                   SubCategoryName = x.SubCategory.Name,
                   ImagePath = x.ImagePath
               });
                return await product.ToListAsync();
            }
        } 
    }
}