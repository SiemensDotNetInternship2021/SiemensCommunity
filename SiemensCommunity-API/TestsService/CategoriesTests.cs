using System;
using Service.Models;
using Service.Contracts;
using Service.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Data.Contracts;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace Service.Tests
{
    public class CategoriesTests
    {
        //the subject of the test
        private CategoryService categoryService;


        private Mock<ICategoryService> categoryServiceMock;
        private Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
        Mock<ILoggerFactory> _loggerFactory;
        Mock<ILogger> mockLogger = new Mock<ILogger>();


        //mock objects
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

            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));
            _loggerFactory = new Mock<ILoggerFactory>();
            _loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);

            categoryService = new CategoryService(categoryRepositoryMock.Object, _loggerFactory.Object);
        }

        [Test]
        public async Task GetCategories_ShouldReturnListOfCategory()
        {
            var result2 = categoryRepositoryMock.Setup(c => c.GetAsync()).Returns(Task.FromResult(dataCategories.AsEnumerable()));

            var result = await categoryService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<Category>>(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetCategories_ShouldReturnEmptyListOfCategory()
        {
            var result2 = categoryRepositoryMock.Setup(c => c.GetAsync()).Returns(Task.FromResult(new List<Data.Models.Category>().AsEnumerable()));

            var result = await categoryService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<Category>>(result);
            Assert.IsEmpty(result);
        }
    }
}
