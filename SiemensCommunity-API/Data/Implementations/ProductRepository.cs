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

        public async Task<ProductFormDTO> FindById(int id)
        {
            var product = await Context.Products.Where(p => p.Id == id)
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .Select( p => new ProductFormDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Photo = p.Photo.Url,
                    Details = p.Details,
                    Category = p.Category,
                    SubCategory = p.SubCategory
                }).SingleOrDefaultAsync();
            return product;
        }
    }
}
