using Data.Contracts;
using Data.Models;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using SiemensCommunity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Categories.Moks
{
    public class CategoryMoks
    {/*
        private CategoryController controller;
        private Mock<ICategoryService> categoryServiceMock;
        private List<Service.Models.Category> categories;

        [SetUp]
        public void Setup()
        {
            var cartegoryItemMock = new Mock<Service.Models.Category>();
            cartegoryItemMock.Setup(item => item.Name).Returns("");
            categories = new List<Service.Models.Category>()
            {
                cartegoryItemMock.Object
            };

            categoryServiceMock.Setup(c => c.GetAsync()).Returns(Task.FromResult(categories.AsEnumerable()));

            controller = new CategoryController(categoryServiceMock.Object);
        }

        [Test]
        public void GetCategories_ShouldReturnList()
        {
            categoryServiceMock.Setup(p => p.GetAsync()).Returns((Task<IEnumerable<Service.Models.Category>>)categories.AsEnumerable());

            var result = controller.GetCategories();

            Assert.AreEqual(categories, result);
        }*/
    }
}