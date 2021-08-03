using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiemensCommunity.Controllers;
using Moq;
using Service.Contracts;
using NUnit.Framework;
using SiemensCommunity.Models;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Tests
{
    public class CategoryTests
    {
        private Mock<CategoryController> catgeoryControllerMock;
        private Mock<ICategoryService> categoryServiceMock;
        CategoryController categoryController;

        private List<Service.Models.Category> dataSubCategories = new List<Service.Models.Category>{
            new Service.Models.Category (){Id = 1, Name = "Subcategory 1"},
            new Service.Models.Category (){Id = 2, Name = "Subcategory 2"},
            new Service.Models.Category (){Id = 3, Name = "Subcategory 3"}
        };

        [SetUp]
        public void SetUp()
        {
            categoryServiceMock = new Mock<ICategoryService>(MockBehavior.Strict);
            catgeoryControllerMock = new Mock<CategoryController>();
            categoryController = new CategoryController(categoryServiceMock.Object);
        }

        [Test]
        public async Task GetCategories_ShouldReturnListOfCategory()
        {
            categoryServiceMock.Setup(p => p.GetAsync()).Returns(Task.FromResult(dataSubCategories.AsEnumerable()));

            var result = await categoryController.Get();

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
