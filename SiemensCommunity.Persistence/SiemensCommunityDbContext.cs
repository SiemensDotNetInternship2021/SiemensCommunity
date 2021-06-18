using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiemensCommunity.Persistence.Models.Entities;
using System;

namespace SiemensCommunity.Persistence
{
    public class SiemensCommunityDbContext : IdentityDbContext<User>
    {
        public SiemensCommunityDbContext(DbContextOptions<SiemensCommunityDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<BorrowedProduct> BorrowedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
