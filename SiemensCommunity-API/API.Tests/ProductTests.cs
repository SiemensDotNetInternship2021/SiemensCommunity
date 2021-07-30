using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Service.Contracts;
using Service.Models;
using SiemensCommunity.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Tests
{
    public class ProductTests
    {
        private Mock<ProductController> productControllerMock;
        private Mock<IProductService> productServiceMock;
        ProductController productController;


        [SetUp]
        public void SetUp()
        {
            productServiceMock = new Mock<IProductService>();
            productControllerMock = new Mock<ProductController>() { CallBase = true };
            productController = new ProductController(productServiceMock.Object);
        }

        [Test]
        public async Task Add_ShouldReturnProduct()
        {
            AddProduct addProductService = new AddProduct() {File = new Mock<IFormFile>().Object, CategoryId =2,SubCategoryId = 1,UserId =1, Details = "json with details", Name = "new product" };
            SiemensCommunity.Models.AddProduct addProductApi = new SiemensCommunity.Models.AddProduct() {Files = new Mock<IFormFileCollection>().Object, CategoryId =2,SubCategoryId = 1,UserId =1, Details = "json with details", Name = "new product" };
            Product product = new Product {CategoryId = 2,SubCategoryId = 1,UserId = 1,Details = "json with details", Name = "new product",PhotoId = 1};
            
            productServiceMock.Setup(p => p.AddAsync(addProductService)).Returns(Task.FromResult(product));

            var result = await productController.Add(addProductApi);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
