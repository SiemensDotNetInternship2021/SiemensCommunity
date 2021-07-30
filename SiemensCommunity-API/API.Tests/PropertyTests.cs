using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using SiemensCommunity.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Tests
{
    public class PropertyTests
    {
        private Mock<PropertyController> propertyControllerMock;
        private Mock<IPropertyService> propertyServiceMock;
        PropertyController propertyController;

        private List<Service.Models.Property> dataProperty = new List<Service.Models.Property>{
            new Service.Models.Property (){Id = 1, Name = "Property 1", CategoryId =1},
            new Service.Models.Property (){Id = 2, Name = "Property 2", CategoryId =1},
            new Service.Models.Property (){Id = 3, Name = "Property 3", CategoryId =2}
        };
        int categoryId = 1;

        [SetUp]
        public void SetUp()
        {
            propertyServiceMock = new Mock<IPropertyService>(MockBehavior.Strict);
            propertyControllerMock = new Mock<PropertyController>();
            propertyController = new PropertyController(propertyServiceMock.Object);
        }

        [Test]
        public async Task GetDepartments_ShouldReturnListOfDepartements()
        {
            propertyServiceMock.Setup(p => p.GetCategoryProperties(categoryId)).Returns(Task.FromResult(dataProperty.Where(p => p.CategoryId == categoryId).AsEnumerable()));

            var result = await propertyController.GetCategoryProperties(categoryId);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
