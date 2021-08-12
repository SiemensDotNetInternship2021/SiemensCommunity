﻿using Data.Contracts;
using Data.Implementations;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Tests
{
    public class CategoriesTests
    {
        private CategoryRepository repository;
        private List<Category> categories;
        DbContextOptions<ProjectDbContext> options = new DbContextOptionsBuilder<ProjectDbContext>()
                                     .UseInMemoryDatabase(databaseName: "SiemensCommunityTests")
                                     .Options;
        private ProjectDbContext dbContext;


        [SetUp]
        public void Setup()
        {
            
            dbContext = new ProjectDbContext(options);
            repository = new CategoryRepository(dbContext);
        }

        [Test]
        public async Task GetCategories_ShouldReturnListOfCategories()
        {
            using (var context = new ProjectDbContext(options))
            {
                context.Categories.Add(new Category { Id = 1, Name = "Category 1" });
                context.Categories.Add(new Category { Id = 2, Name = "Category 2" });
                context.Categories.Add(new Category { Id = 3, Name = "Category 3" });
                context.SaveChanges();
            }

            var result = await repository.GetAsync();

            Assert.AreEqual(3, result.Count());
        }


        [Test]
        public async Task GetCategories_ShouldReturnEmptyListOfCategories()
        {
            using (var context = new ProjectDbContext(options))
            {
                context.SaveChanges();
            }

            var result = await repository.GetAsync();

            Assert.IsEmpty(result);
        }
    }
}
