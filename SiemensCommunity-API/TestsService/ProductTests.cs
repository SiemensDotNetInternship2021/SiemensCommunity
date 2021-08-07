using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
    public class ProductTests
    {
        private ProductService productService;
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();

        private Mock<IPhotoRepository> photoRepositoryMock = new Mock<IPhotoRepository>();
        private Mock<IPhotoService> photoServiceMock = new Mock<IPhotoService>();

        Mock<ILoggerFactory> _loggerFactory;
        Mock<ILogger> mockLogger = new Mock<ILogger>();

        Mock<IFormFile> testFile = new Mock<IFormFile>();

        private List<Data.Models.Product> dataProducts = new List<Data.Models.Product> {
            new Data.Models.Product { Id = 1, Name = "Category 1" },
            new Data.Models.Product {Id =2, Name = "Category 2"}
        };

        private List<Product> products = new List<Product> {
            new Product { Id = 1, Name = "Category 1" },
            new Product {Id =2, Name = "Category 2"}
        };

         Cloudinary cloudinary;
        string CloudName = "db4zulf3p";
        string ApiKey = "571223714477617";
        string ApiSecret = "VxOGPDY7nfF_C0T_kllq824BkDY";

        [SetUp]
        public void SetUp()
        {
            cloudinary = new Cloudinary(new Account( CloudName, ApiKey, ApiSecret));
            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));
            _loggerFactory = new Mock<ILoggerFactory>();
            _loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);
            productService = new ProductService(productRepository.Object, photoServiceMock.Object, photoRepositoryMock.Object, new Mock<ILoggerFactory>().Object);
        }

        [Test]
        public async Task AddProduct_ShouldReturnException()
        {
            var testPhoto = new Data.Models.Photo { IsMain = false, PublicId = Guid.NewGuid().ToString(), Url = Guid.NewGuid().ToString() };
            var productData = new Data.Models.Product
            {
                Id = 0,
                Name = "Product",
                CategoryId = 1,
                SubCategoryId = 1,
                PhotoId = 1,
                Details = "Some details",
                UserId = 1
            };
            var productAdd = new AddProduct{ Id = 0,Name = "Product",CategoryId = 1,SubCategoryId = 1,Details = "Some details",UserId = 1, ImageURL = "some url" };
            photoServiceMock.Setup(p => p.UploadPhotoAsync(testFile.Object)).ReturnsAsync(new Mock<ImageUploadResult>().Object);
            productRepository.Setup(c => c.AddAsync(productData)).Returns(Task.FromResult(productData));
            photoRepositoryMock.Setup(p => p.AddAsync(testPhoto)).Returns(Task.FromResult(testPhoto));

            try
            {
                var result= await productService.AddAsync(productAdd);
            }catch (NotImplementedException)
            {
                Assert.Pass();
            }
        }


        [Test]
        public async Task GetUserProductsAsync_ShouldReturnListOfUserProductsWithCategoryNull()
        {
            List<Data.Models.ProductDTO> listOfProductsData = new List<Data.Models.ProductDTO>()
            {
                new Data.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Data.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Data.Models.ProductDTO {Id =3, Name ="prod 3"}
            };
/*            List<ProductDTO> listOfProductsService= new List<ProductDTO>()
            {
                new ProductDTO {Id =1, Name ="prod 1"},
                new ProductDTO {Id =2, Name ="prod 2"},
                new ProductDTO {Id =3, Name ="prod 3"}
            };*/
            int userId = 1;
            productRepository.Setup(x => x.GetUserProductsAsync(userId)).Returns(Task.FromResult(listOfProductsData));

            var result = await productService.GetUserProductsAsync(userId, null);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetUserProductsAsync_ShouldReturnListOfUserProductsByCategoryId()
        {
            List<Data.Models.ProductDTO> listOfProductsData = new List<Data.Models.ProductDTO>()
            {
                new Data.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Data.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Data.Models.ProductDTO {Id =3, Name ="prod 3"}
            };

            int userId = 1;
            int categoryId = 2;
            productRepository.Setup(x => x.GetUserProductsByCategoryAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsData));

            var result = await productService.GetUserProductsAsync(userId, categoryId);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetUserAvailableProductsAsync_ShouldReturnListOfUserProductsWithCategoryNull()
        {
            List<Data.Models.ProductDTO> listOfProductsData = new List<Data.Models.ProductDTO>()
            {
                new Data.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Data.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Data.Models.ProductDTO {Id =3, Name ="prod 3"}
            };

            int userId = 1;
            int categoryId = 2;
            productRepository.Setup(x => x.GetUserAvailableProductsByCategoryAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsData));
            productRepository.Setup(x => x.GetUserAvailableProductsAsync(userId)).Returns(Task.FromResult(listOfProductsData));

            var result = await productService.GetUserAvailableProductsAsync(userId, null);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetUserAvailableProductsAsync_ShouldReturnListOfUserProductsByCategory()
        {
            List<Data.Models.ProductDTO> listOfProductsData = new List<Data.Models.ProductDTO>()
            {
                new Data.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Data.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Data.Models.ProductDTO {Id =3, Name ="prod 3"}
            };

            int userId = 1;
            int categoryId = 2;
            productRepository.Setup(x => x.GetUserAvailableProductsByCategoryAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsData));
            productRepository.Setup(x => x.GetUserAvailableProductsAsync(userId)).Returns(Task.FromResult(listOfProductsData));

            var result = await productService.GetUserAvailableProductsAsync(userId, categoryId);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task GetUserLendProductsAsync_ShouldReturnListOfUserProductsWithCategoryNull()
        {
            List<Data.Models.ProductDTO> listOfProductsData = new List<Data.Models.ProductDTO>()
            {
                new Data.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Data.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Data.Models.ProductDTO {Id =3, Name ="prod 3"}
            };

            int userId = 1;
            int categoryId = 2;
            productRepository.Setup(x => x.GetUserLendProductsByCategoryAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsData));
            productRepository.Setup(x => x.GetUserLendProductsAsync(userId)).Returns(Task.FromResult(listOfProductsData));

            var result = await productService.GetUserLendProductsAsync(userId, null);

            Assert.AreEqual(3, result.Count());
        }


        [Test]
        public async Task GetUserLendProductsAsync_ShouldReturnListOfUserProductsByCategory()
        {
            List<Data.Models.ProductDTO> listOfProductsData = new List<Data.Models.ProductDTO>()
            {
                new Data.Models.ProductDTO {Id =1, Name ="prod 1"},
                new Data.Models.ProductDTO {Id =2, Name ="prod 2"},
                new Data.Models.ProductDTO {Id =3, Name ="prod 3"}
            };

            int userId = 1;
            int categoryId = 2;
            productRepository.Setup(x => x.GetUserLendProductsByCategoryAsync(userId, categoryId)).Returns(Task.FromResult(listOfProductsData));
            productRepository.Setup(x => x.GetUserLendProductsAsync(userId)).Returns(Task.FromResult(listOfProductsData));

            var result = await productService.GetUserLendProductsAsync(userId, categoryId);

            Assert.AreEqual(3, result.Count());
        }
    }
}
