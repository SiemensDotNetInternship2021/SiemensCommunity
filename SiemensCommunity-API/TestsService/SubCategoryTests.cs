using Data.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using Service.Implementations;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Tests
{
    public class SubCategoryTests
    {
        //subject of the test
        private SubCategoryService subCategoryService;

        private Mock<ISubCategoryRepository> subCategoryRepository = new Mock<ISubCategoryRepository>();
        Mock<ILoggerFactory> _loggerFactory;
        Mock<ILogger> mockLogger = new Mock<ILogger>();

        private List<Data.Models.SubCategory> dataSubCategories = new List<Data.Models.SubCategory> {
            new Data.Models.SubCategory { Id = 1, Name = "Category 1", CategoryId = 1 },
            new Data.Models.SubCategory {Id =2, Name = "Category 2", CategoryId = 2}
        };

        private List<SubCategory> subCategories = new List<SubCategory> {
            new SubCategory { Id = 1, Name = "Category 1", CategoryId = 1 },
            new SubCategory {Id =2, Name = "Category 2", CategoryId = 2}
        };

        [SetUp]
        public void SetUp()
        {
            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));
            _loggerFactory = new Mock<ILoggerFactory>();
            _loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);

            subCategoryService = new SubCategoryService(subCategoryRepository.Object, new Mock<ILogService>().Object ,_loggerFactory.Object);
        }

        [Test]
        public async Task GetCategories_ShouldReturnListOfSubCategories()
        {
            subCategoryRepository.Setup(c => c.GetAsync()).Returns(Task.FromResult(dataSubCategories.AsEnumerable()));

            var result = await subCategoryService.GetAsync();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetCategories_ShouldReturnEmptyListOfSubCategories()
        {
            subCategoryRepository.Setup(c => c.GetAsync()).Returns(Task.FromResult(new List<Data.Models.SubCategory>().AsEnumerable()));

            var result = await subCategoryService.GetAsync();

            Assert.IsEmpty(result);
        }
    }
}
