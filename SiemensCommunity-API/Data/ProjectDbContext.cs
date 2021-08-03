using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProjectDbContext : IdentityDbContext<User, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*builder.Entity<Product>()
                .HasMany(fp => fp.FavoriteProduct)
                .WithOne(fp => fp.Product)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FavoriteProduct>()
                .HasOne(fp => fp.Product)
                .WithMany(fp => fp.FavoriteProduct)
                .OnDelete(DeleteBehavior.Restrict);*/

            /*builder.Entity<Product>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.Products)
            .HasForeignKey(ur => ur.UserId);
            *//*.IsRequired();*//*

            builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();*/

            /*builder.Entity<User>()
            .HasMany(ur => ur.Products)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();*/
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BorrowedProduct> BorrowedProducts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
