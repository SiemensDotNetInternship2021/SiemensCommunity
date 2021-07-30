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
            builder.Entity<Department>().HasData(new Department { Id = 1, Name = "HR" },
                                                 new Department { Id = 2, Name = "Marketing" },
                                                 new Department { Id = 3, Name = "IT" });

            builder.Entity<Category>().HasData(new Category { Id = 1, Name = "Books" },
                                               new Category { Id = 2, Name = "Decorative objects" });

            builder.Entity<SubCategory>().HasData(new SubCategory { Id = 1, CategoryId = 1, Name = "SF" },
                                                  new SubCategory { Id = 2, CategoryId = 1, Name = "Poems" },
                                                  new SubCategory { Id = 3, CategoryId = 2, Name = "Desk" });

            builder.Entity<Product>().HasData(new Product { Id = 1, Name = "Book SF", CategoryId = 1, SubCategoryId = 1, IsAvailable = true, RatingAverage = 3, UserId = 2 },
                                            new Product { Id = 2, Name = "Book Poems", CategoryId = 1, SubCategoryId = 2, IsAvailable = true, RatingAverage = 3, UserId = 2 },
                                            new Product { Id = 3, Name = "Book Poems", CategoryId = 1, SubCategoryId = 2, IsAvailable = true, RatingAverage = 4, UserId = 2 },
                                            new Product { Id = 4, Name = "Book SF", CategoryId = 1, SubCategoryId = 1, IsAvailable = false, RatingAverage = 5, UserId = 2 },
                                            new Product { Id = 5, Name = "Decorative Object", CategoryId = 2, SubCategoryId = 3, IsAvailable = false, RatingAverage = 5, UserId = 2 },
                                            new Product { Id = 6, Name = "Decorative Object 2", CategoryId = 2, SubCategoryId = 5, IsAvailable = false, RatingAverage = 5, UserId = 5 });

            builder.Entity<BorrowedProduct>().HasData(new BorrowedProduct { Id = 1, UserId = 2, ProductId = 4, StartDate = "2021/7/13", EndDate = "2021/7/23" },
                                                      new BorrowedProduct { Id = 2, UserId = 2, ProductId = 4, StartDate = "2021/7/13", EndDate = "2021/7/23" });

            base.OnModelCreating(builder);

            builder.Entity<User>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

            builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BorrowedProduct> BorrowedProducts { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
    }
}
