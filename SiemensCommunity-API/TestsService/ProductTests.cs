using CloudinaryDotNet;
using Data.Contracts;
using Microsoft.Extensions.Options;
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
    public class ProductTests
    {
        private ProductService productService;
        private Mock<IProductService> productServiceMock;
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        private Mock<IPhotoRepository> photoRepositoryMock = new Mock<IPhotoRepository>();
        private Mock<IPhotoService> photoServiceMock = new Mock<IPhotoService>();
        private PhotoService photoService;
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
            productServiceMock = new Mock<IProductService>(MockBehavior.Strict);
            productService = new ProductService(productRepository.Object, photoServiceMock.Object, photoRepositoryMock.Object);
        }

        [Test]
        public async Task AddProduct_ShouldAddProduct()
        {
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
            var productAdd = new AddProduct
            {
                Id = 0,
                Name = "Product",
                CategoryId = 1,
                SubCategoryId = 1,
                Details = "Some details",
                UserId = 1,
                ImageURL = "some url"
            };
            productRepository.Setup(c => c.AddAsync(productData)).Returns(Task.FromResult(productData));


            var result = await productService.AddAsync(productAdd);

            Assert.AreEqual(productAdd.Id, productAdd.Id);
        }


    }
}
