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
            builder.Entity<LogLevel>().HasData(
                new LogLevel { Id = 1, CodeId = 0, Name = "Trace" },
                new LogLevel { Id=2, CodeId = 1, Name = "Debug" },
                new LogLevel { Id = 3, CodeId = 2, Name = "Information" },
                new LogLevel { Id = 4, CodeId = 3, Name = "Warning" },
                new LogLevel { Id = 5, CodeId = 4, Name = "Error" },
                new LogLevel { Id = 6, CodeId = 5, Name = "Critical" },
                new LogLevel { Id = 7, CodeId = 6, Name = "None" }
                );

            builder.Entity<LogEvent>().HasData(
                new LogEvent { Id = 1, CodeId = 1000, Name = "GenerateItems" },
                new LogEvent { Id = 2, CodeId = 1001, Name = "ListItems" },
                new LogEvent { Id = 3, CodeId = 1002, Name = "GetItem" },
                new LogEvent { Id = 4, CodeId = 1003, Name = "InsertItem" },
                new LogEvent { Id = 5, CodeId = 1004, Name = "UpdateItem" },
                new LogEvent { Id = 6, CodeId = 1005, Name = "DeleteItem" },
                new LogEvent { Id = 7, CodeId = 2000, Name = "EmailSent" },
                new LogEvent { Id = 8, CodeId = 2001, Name = "ErrorEmailSent" },
                new LogEvent { Id = 9, CodeId = 3000, Name = "TestItem" },
                new LogEvent { Id = 10, CodeId = 3001, Name = "UploadItem" },
                new LogEvent { Id = 11, CodeId = 3002, Name = "ErrorUploadItem" }
            );

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

            builder.Entity<FavoriteProduct>()
            .HasOne(p => p.Product)
            .WithMany(f => f.FavoriteProduct)
            .OnDelete(DeleteBehavior.ClientCascade);
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
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogEvent> LogEvents { get; set; }
        public DbSet<LogLevel> LogLevels { get; set; }
    }
}
