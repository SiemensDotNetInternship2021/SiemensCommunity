using Data.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using Service.Implementations;
using Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Tests
{
    public class SubCategoryTests
    {
        private SubCategoryService subCategoryService;
        private Mock<ISubCategoryService> subCategoryServiceMock;
        private Mock<ISubCategoryRepository> subCategoryRepository = new Mock<ISubCategoryRepository>();
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
            subCategoryServiceMock = new Mock<ISubCategoryService>(MockBehavior.Strict);
            subCategoryService = new SubCategoryService(subCategoryRepository.Object, new Mock<ILoggerFactory>().Object);
        }

        [Test]
        public async Task GetCategories_ShouldReturnListOfCategory()
        {
            subCategoryRepository.Setup(c => c.GetAsync()).Returns(Task.FromResult(dataSubCategories.AsEnumerable()));
            subCategoryServiceMock.Setup(p => p.GetAsync()).Returns(Task.FromResult(subCategories.AsEnumerable()));

            var result = await subCategoryService.GetAsync();

            Assert.IsInstanceOf<IEnumerable<SubCategory>>(result);
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
