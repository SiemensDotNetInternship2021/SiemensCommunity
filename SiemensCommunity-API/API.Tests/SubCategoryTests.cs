using System;
using System.Collections.Generic;
using SiemensCommunity;
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

namespace API.Tests
{
    public class SubCategoryTests
    {
        private Mock<SubCategoryController> subCatgeoryControllerMock;
        private Mock<ISubCategoryService> subCategoryServiceMock;
        SubCategoryController subCategoryController;
        private HttpClient client;
        string baseUrl = "https://localhost:52718/api";

        private List<Service.Models.SubCategory> dataSubCategories = new List<Service.Models.SubCategory>{
            new Service.Models.SubCategory (){Id = 1, Name = "Subcategory 1", CategoryId = 1},
            new Service.Models.SubCategory (){Id = 2, Name = "Subcategory 2", CategoryId = 1},
            new Service.Models.SubCategory (){Id = 3, Name = "Subcategory 3", CategoryId = 2}
        };

        [SetUp]
        public void SetUp()
        {
            client = new HttpClient();
            subCategoryServiceMock = new Mock<ISubCategoryService>(MockBehavior.Strict);
            subCatgeoryControllerMock = new Mock<SubCategoryController>();
            subCategoryController = new SubCategoryController(subCategoryServiceMock.Object);
        }

        [Test]
        public async Task GetSubCategories_ShouldReturnListOfCategory()
        {
            subCategoryServiceMock.Setup(p => p.GetAsync()).Returns(Task.FromResult(dataSubCategories.AsEnumerable()));

            var result = await subCategoryController.GetSubCategories();

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
