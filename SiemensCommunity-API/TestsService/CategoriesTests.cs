using System;
using Service.Models;
using Service.Contracts;
using Service.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Implementations;
using Moq;
using Data.Contracts;
using NUnit.Framework;

namespace Service.Tests
{
    public class CategoriesTests
    {
        private CategoryService categoryService;
        private Mock<ICategoryService> categoryServiceMock;
        private Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>();
        private List<Data.Models.Category> dataCategories = new List<Data.Models.Category> {
            new Data.Models.Category { Id = 1, Name = "Category 1" },
            new Data.Models.Category {Id =2, Name = "Category 2"}
        };

        private List<Category> categories = new List<Category> {
            new Category { Id = 1, Name = "Category 1" },
            new Category {Id =2, Name = "Category 2"}
        };

        [SetUp]
        public void SetUp()
        {
            categoryServiceMock = new Mock<ICategoryService>(MockBehavior.Strict);
            categoryService = new CategoryService(categoryRepository.Object);
        }

        [Test]
        public async Task GetCategories_ShouldReturnListOfCategory()
        {
            categoryRepository.Setup(c => c.GetAsync()).Returns(Task.FromResult(dataCategories.AsEnumerable()));
            categoryServiceMock.Setup(p => p.GetAsync()).Returns(Task.FromResult(categories.AsEnumerable()));

            var result = await categoryService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<Category>>(result);
            Assert.AreEqual(result.Count(), 2);
        }


    }
}
