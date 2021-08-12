using System;
using Data.Models;
using Data.Contracts;
using Data.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests
{
    public class PropertiesTests
    {
        private PropertyRepository repository;
        private List<Property> properties = new List<Property>
        {
            new Property { Id = 1, Name = "Category 1", CategoryId = 1},
            new Property { Id = 2, Name = "Category 2", CategoryId = 2},
            new Property { Id = 3, Name = "Category 3", CategoryId = 3}
        };

        DbContextOptions<ProjectDbContext> options = new DbContextOptionsBuilder<ProjectDbContext>()
                                                     .UseInMemoryDatabase(databaseName: "SiemensCommunityTests")
                                                     .Options;
        private ProjectDbContext dbContext;

        [SetUp]
        public void Setup()
        {

            dbContext = new ProjectDbContext(options);
            repository = new PropertyRepository(dbContext);
        }

        [Test]
        public async Task GetProperties_ShouldReturnListOfProperties()
        {
            int categoryId = 1;
            using (var context = new ProjectDbContext(options))
            {
                context.Properties.Add(new Property { Id = 1, Name = "Category 1", CategoryId = 1 });
                context.Properties.Add(new Property { Id = 2, Name = "Category 2", CategoryId = 2 });
                context.Properties.Add(new Property { Id = 3, Name = "Category 3", CategoryId = 3 });
                context.SaveChanges();
            }

            var result = await repository.GetAsync();

            Assert.AreEqual(result.Count(), 3);
        }

        [Test]
        public async Task GetProperties_ShouldReturnEmptyListOfProperties()
        {
            using (var context = new ProjectDbContext(options))
            {
                context.SaveChanges();
            }

            var result = await repository.GetAsync();

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetProperties_ShouldReturnListOfPropertiesbyCategoryId()
        {
            int categoryId = 1;
            using (var context = new ProjectDbContext(options))
            {
                context.Properties.Add(new Property { Id = 1, Name = "Category 1", CategoryId = 1 });
                context.Properties.Add(new Property { Id = 2, Name = "Category 2", CategoryId = 2 });
                context.Properties.Add(new Property { Id = 3, Name = "Category 3", CategoryId = 3 });
                context.SaveChanges();
            }

            var result = await repository.GetCategoryProperties(categoryId);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public async Task GetProperties_ShouldReturnEmptyListOfPropertiesbyCategoryIdIfCategoryIdDoesNotExists()
        {
            int categoryId = 4;
            using (var context = new ProjectDbContext(options))
            {
                context.Properties.Add(new Property { Id = 1, Name = "Category 1", CategoryId = 1 });
                context.Properties.Add(new Property { Id = 2, Name = "Category 2", CategoryId = 2 });
                context.Properties.Add(new Property { Id = 3, Name = "Category 3", CategoryId = 3 });
                context.SaveChanges();
            }

            var result = await repository.GetCategoryProperties(categoryId);

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetProperties_ShouldReturnEmptyListOfPropertiesbyCategoryIdIFNoDataInProperties()
        {
            int categoryId = 4;
            using (var context = new ProjectDbContext(options))
            {
                context.SaveChanges();
            }

            var result = await repository.GetCategoryProperties(categoryId);

            Assert.IsEmpty(result);
        }
    }
}
