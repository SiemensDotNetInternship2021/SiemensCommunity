using System;
using Data.Contracts;
using Service.Implementations;
using Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Service.Contracts;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace Service.Tests
{
    public class PropertiesTests
    {
        //subject of the test
        private PropertyService propertyService;

        //mocks
        private Mock<IPropertyRepository> propertyRepositoryMock = new Mock<IPropertyRepository>();
        Mock<ILoggerFactory> _loggerFactory;
        Mock<ILogger> mockLogger = new Mock<ILogger>();

        private List<Data.Models.Property> dataProperty = new List<Data.Models.Property> {
            new Data.Models.Property { Id = 1, Name = "property 1", CategoryId = 1 },
            new Data.Models.Property { Id = 2, Name = "property 2", CategoryId = 2}
        };

        private List<Property> properties = new List<Property> {
            new Property { Id = 1, Name = "property 1", CategoryId = 1 },
            new Property {Id =2, Name = "property 2", CategoryId = 2}
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

            propertyService = new PropertyService(propertyRepositoryMock.Object, _loggerFactory.Object);
        }


        [Test]
        public async Task GetCategoryProperties_ShouldReturnListOfProperties()
        {
            var categoryId = 1;
            propertyRepositoryMock.Setup(c => c.GetCategoryProperties(categoryId))
                .Returns(Task.FromResult(dataProperty.Where(c => c.CategoryId == categoryId).AsEnumerable()));

            var result = await propertyService.GetCategoryProperties(categoryId);

            Assert.AreEqual(1, result.Count());
        }


        [Test]
        public async Task GetCategoryProperties_ShouldReturnEmptyListOfProperties()
        {
            var categoryId = 3;
            propertyRepositoryMock.Setup(c => c.GetCategoryProperties(categoryId)).Returns(Task.FromResult(dataProperty.Where(p => p.CategoryId == categoryId)));

            var result = await propertyService.GetCategoryProperties(categoryId);

            Assert.IsEmpty(result);
        }
    }
}
