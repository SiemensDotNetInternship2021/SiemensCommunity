using Data.Models;
using Data.Implementations;
using Data.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Data.Tests
{
    public class SubCategoryTests
    {
        private SubCategoryRepository repository;
        private List<SubCategory> subCategories;
        DbContextOptions<ProjectDbContext> options = new DbContextOptionsBuilder<ProjectDbContext>()
                                     .UseInMemoryDatabase(databaseName: "SiemensCommunityTests")
                                     .Options;
        private ProjectDbContext dbContext;


        [SetUp]
        public void Setup()
        {
            using (var context = new ProjectDbContext(options))
            {
                context.SubCategories.Add(new SubCategory { Id = 1, Name = "Category 1" });
                context.SubCategories.Add(new SubCategory { Id = 2, Name = "Category 2" });
                context.SubCategories.Add(new SubCategory { Id = 3, Name = "Category 3" });
                context.SaveChanges();
            }
            dbContext = new ProjectDbContext(options);
            repository = new SubCategoryRepository(dbContext);
        }

        [Test]
        public async Task GetSubCategories_ShouldReturnListOfSubCategories()
        {
            var result = await repository.GetAsync();

            Assert.AreEqual(3, result.Count());
        }

    }
}
