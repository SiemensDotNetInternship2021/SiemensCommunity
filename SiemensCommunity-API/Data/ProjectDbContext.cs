using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
