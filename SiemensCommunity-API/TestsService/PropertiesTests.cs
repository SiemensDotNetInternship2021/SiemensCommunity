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
        private PropertyService propertyService;
        private Mock<IPropertyService> propertyServiceMock;
        private Mock<IPropertyRepository> propertyRepositoryMock = new Mock<IPropertyRepository>();
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
            propertyServiceMock = new Mock<IPropertyService>(MockBehavior.Strict);
            propertyService = new PropertyService(propertyRepositoryMock.Object, new Mock<ILoggerFactory>().Object);
        }


        [Test]
        public async Task GetCategoryProperties_ShouldReturnListOfProperties()
        {
            var categoryId = 1;
            var dataProperty = new List<Data.Models.Property>{ new Data.Models.Property { Id = 1, Name = "property 1", CategoryId = 1 } };
            var property = new List<Property>{ new Property { Id = 1, Name = "property 1", CategoryId = 1 } };
            propertyRepositoryMock.Setup(c => c.GetCategoryProperties(categoryId)).Returns(Task.FromResult(dataProperty.AsEnumerable()));
            propertyServiceMock.Setup(p => p.GetCategoryProperties(categoryId)).Returns(Task.FromResult(property.AsEnumerable()));

            var result = await propertyService.GetCategoryProperties(categoryId);

            Assert.AreEqual(1, result.Count());
        }


        [Test]
        public async Task GetCategoryProperties_ShouldNotReturnListOfProperties()
        {
            var categoryId = 3;
            propertyRepositoryMock.Setup(c => c.GetCategoryProperties(categoryId)).Returns(Task.FromResult(new List<Data.Models.Property>().AsEnumerable()));
            propertyServiceMock.Setup(p => p.GetCategoryProperties(categoryId)).Returns(Task.FromResult(new List<Property>().AsEnumerable()));

            var result = await propertyService.GetCategoryProperties(categoryId);

            Assert.AreEqual(0, result.Count());
        }
    }
}
