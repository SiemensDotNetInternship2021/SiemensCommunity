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
                                               new Category { Id = 2, Name = "Decorative objects" },
                                               new Category { Id = 3, Name = "Electronics"});


            builder.Entity<SubCategory>().HasData(new SubCategory { Id = 1, CategoryId = 1, Name = "SF" },
                                                  new SubCategory { Id = 2, CategoryId = 1, Name = "Poems" },
                                                  new SubCategory { Id = 3, CategoryId = 2, Name = "Desk" },
                                                  new SubCategory { Id = 4, CategoryId = 1, Name = "Thrillers" },
                                                  new SubCategory { Id = 5, CategoryId = 2, Name = "Chair"},
                                                  new SubCategory { Id = 6, CategoryId = 3, Name = "TV"});

            builder.Entity<Product>().HasData(new Product { Id = 1, Name = "Book SF", CategoryId = 1, SubCategoryId = 1, IsAvailable = true, Rating = 3, UserId = 2 },
                                            new Product { Id = 2, Name = "Book Poems", CategoryId = 1, SubCategoryId = 2, IsAvailable = true, Rating = 3, UserId = 2 },
                                            new Product { Id = 3, Name = "Book Poems", CategoryId = 1, SubCategoryId = 2, IsAvailable = true, Rating = 4, UserId = 2 },
                                            new Product { Id = 4, Name = "Book SF", CategoryId = 1, SubCategoryId = 1, IsAvailable = false, Rating = 5, UserId = 2 },
                                            new Product { Id = 5, Name = "Decorative Object", CategoryId = 2, SubCategoryId = 3, IsAvailable = false, Rating = 5, UserId = 2 },
                                            new Product { Id = 6, Name = "Decorative Object 2", CategoryId = 2, SubCategoryId = 5, IsAvailable = false, Rating = 5, UserId = 5 },
                                            new Product { Id = 7, Name = "Book Thriller", CategoryId = 1, SubCategoryId = 4, IsAvailable = true, Rating = 4, UserId = 4 },
                                            new Product { Id = 8, Name = "Samsung TV", CategoryId = 3, SubCategoryId = 6, IsAvailable = true, Rating = 4, UserId = 6 });

            builder.Entity<BorrowedProduct>().HasData(new BorrowedProduct { Id = 1, UserId = 2, ProductId = 4, StartDate = "2021/7/13", EndDate = "2021/7/23" },
                                                      new BorrowedProduct { Id = 2, UserId = 2, ProductId = 4, StartDate = "2021/7/13", EndDate = "2021/7/23" },
                                                      new BorrowedProduct { Id = 3, UserId = 4, ProductId = 7, StartDate = "2021/7/13", EndDate = "2021/7/23" },
                                                      new BorrowedProduct { Id = 4, UserId = 6, ProductId = 8, StartDate = "2021/7/13", EndDate = "2021/7/23" },
                                                      new BorrowedProduct { Id = 5, UserId = 5, ProductId = 6, StartDate = "2021/7/13", EndDate = "2021/7/23" });

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
    }
}
