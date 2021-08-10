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

            builder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(e => e.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();



         /*   builder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
             .HasMany(e => e.UserRoles)
             .WithOne()
             .HasForeignKey(e => e.RoleId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);*/

          /*  builder.Entity<AppRole>()
              .HasMany(e => e.UserRoles)
              .WithOne(e => e.Role)
              .HasForeignKey(e => e.UserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppRole>()
           .HasMany(e => e.UserRoles)
           .WithOne(e => e.Role)
           .HasForeignKey(e => e.RoleId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Cascade);*/

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
