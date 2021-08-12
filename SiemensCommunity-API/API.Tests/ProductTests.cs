using Microsoft.AspNetCore.Http;
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
            Service.Models.AddProduct addProductService = new Service.Models.AddProduct() { File = new Mock<IFormFile>().Object, CategoryId = 2, SubCategoryId = 1, UserId = 1, Details = "json with details", Name = "new product" };
            SiemensCommunity.Models.AddProduct addProductApi = new SiemensCommunity.Models.AddProduct() { Files = new Mock<IFormFileCollection>().Object, CategoryId = 2, SubCategoryId = 1, UserId = 1, Details = "json with details", Name = "new product" };
            Service.Models.Product product = new Service.Models.Product { CategoryId = 2, SubCategoryId = 1, UserId = 1, Details = "json with details", Name = "new product", PhotoId = 1 };

            productServiceMock.Setup(p => p.AddAsync(addProductService)).Returns(Task.FromResult(product));

            var result = await productController.Add(addProductApi);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetUserProducts_ShouldReturnListOfUserProductsWithCategoryNull()
        {
            int userId = 1;
            List<Service.Models.ProductDTO> listOfProductsService = new List<Service.Models.ProductDTO>()
            {
                new Service.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Service.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Service.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
            productServiceMock.Setup(x => x.GetUserProductsAsync(userId, null)).Returns(Task.FromResult(listOfProductsService));

            var result = await productController.GetUserProducts(userId, null);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetUserProducts_ShouldReturnListOfUserProductsByCategoryId()
        {
            int userId = 1;
            int categoryId = 1;
            List<Service.Models.ProductDTO> listOfProductsService = new List<Service.Models.ProductDTO>()
            {
                new Service.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Service.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Service.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
            productServiceMock.Setup(x => x.GetUserProductsAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsService));

            var result = await productController.GetUserProducts(userId, categoryId);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetUserAvailableProducts_ShouldReturnListOfUserProductsWithcategoryNull()
        {
            int userId = 1;
            List<Service.Models.ProductDTO> listOfProductsService = new List<Service.Models.ProductDTO>()
            {
                new Service.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Service.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Service.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
            productServiceMock.Setup(x => x.GetUserAvailableProductsAsync(userId, null)).Returns(Task.FromResult(listOfProductsService));

            var result = await productController.GetUserAvailableProducts(userId, null);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetUserAvailableProducts_ShouldReturnListOfUserProductsByCategoryId()
        {
            int userId = 1;
            int categoryId = 1;
            List<Service.Models.ProductDTO> listOfProductsService = new List<Service.Models.ProductDTO>()
            {
                new Service.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Service.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Service.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
            productServiceMock.Setup(x => x.GetUserAvailableProductsAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsService));

            var result = await productController.GetUserAvailableProducts(userId, categoryId);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetUserLentedProducts_ShouldReturnListOfUserProductsWithCategoryNull()
        {
            int userId = 1;
            List<Service.Models.ProductDTO> listOfProductsService = new List<Service.Models.ProductDTO>()
            {
                new Service.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Service.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Service.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
            productServiceMock.Setup(x => x.GetUserLendProductsAsync(userId, null)).Returns(Task.FromResult(listOfProductsService));

            var result = await productController.GetUserLentedProducts(userId, null);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetUserLentedProducts_ShouldReturnListOfUserProductsByCategoryId()
        {
            int userId = 1;
            int categoryId = 1;
            List<Service.Models.ProductDTO> listOfProductsService = new List<Service.Models.ProductDTO>()
            {
                new Service.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Service.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Service.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
            productServiceMock.Setup(x => x.GetUserLendProductsAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsService));

            var result = await productController.GetUserLentedProducts(userId, categoryId);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
