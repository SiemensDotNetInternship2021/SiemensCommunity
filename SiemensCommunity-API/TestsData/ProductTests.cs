using Data.Contracts;
using Data.Implementations;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests
{
    public class ProductTests
    {
        private ProductRepository repository;
        private Mock<IProductRepository> productRepositoryMock;
        private List<Product> products;
        DbContextOptions<ProjectDbContext> options = new DbContextOptionsBuilder<ProjectDbContext>()
                                     .UseInMemoryDatabase(databaseName: "SiemensCommunityTests")
                                     .Options;
        private ProjectDbContext dbContext;


        [SetUp]
        public void Setup()
        {
            using (var context = new ProjectDbContext(options))
            {
                context.Products.Add(new Product { Id = 1, Name = "Product 1" });
                context.Products.Add(new Product { Id = 2, Name = "Product 2" });
                context.Products.Add(new Product { Id = 3, Name = "Product 3" });
                context.SaveChanges();
            }
            productRepositoryMock = new Mock<IProductRepository>();
            dbContext = new ProjectDbContext(options);
            repository = new ProductRepository(dbContext);
        }

        [Test]
        public async Task AddProduct_ShouldAddProduct()
        {
            var testProduct = new Product
            {
                Name = "Product 1",
                CategoryId = 1,
                SubCategoryId = 1,
                UserId = 1,
                Details = "some details",
                PhotoId = 1
            };
            productRepositoryMock.Setup(p => p.AddAsync(testProduct)).Returns(Task.FromResult(testProduct));

            var result = await repository.AddAsync(testProduct);

            Assert.AreEqual(result.Name, testProduct.Name);
            Assert.AreEqual(result.CategoryId, testProduct.CategoryId);
            Assert.AreEqual(result.SubCategoryId, testProduct.SubCategoryId);
            Assert.AreEqual(result.UserId, testProduct.UserId);
            Assert.AreEqual(result.Details, testProduct.Details);
            Assert.AreEqual(result.PhotoId, testProduct.PhotoId);
        }

        [Test]
        public async Task UpdateProduct_ShouldUpdateProduct()
        {
            var testProduct = new Product
            {
                Id = 1,
                Name = "Product 1",
                CategoryId = 1,
                SubCategoryId = 1,
                UserId = 1,
                Details = "some details",
                PhotoId = 1
            };
            productRepositoryMock.Setup(p => p.UpdateAsync(testProduct, testProduct.Id)).Returns(Task.FromResult(testProduct));

            var result = await repository.UpdateAsync(testProduct, testProduct.Id);

            Assert.AreEqual(result.Name, testProduct.Name);
            Assert.AreEqual(result.CategoryId, testProduct.CategoryId);
            Assert.AreEqual(result.SubCategoryId, testProduct.SubCategoryId);
            Assert.AreEqual(result.UserId, testProduct.UserId);
            Assert.AreEqual(result.Details, testProduct.Details);
            Assert.AreEqual(result.PhotoId, testProduct.PhotoId);
        }

        [Test]
        public async Task UpdateProduct_ProductNotFound()
        {
            var testProduct = new Product
            {
                Id = 10,
                Name = "Product 1",
                CategoryId = 1,
                SubCategoryId = 1,
                UserId = 1,
                Details = "some details",
                PhotoId = 1
            };
            productRepositoryMock.Setup(p => p.UpdateAsync(testProduct, testProduct.Id)).Throws(new ArgumentNullException());
            try
            {
                await repository.UpdateAsync(testProduct, testProduct.Id);

            }catch(ArgumentNullException ex)
            {
                Assert.Pass();
            }
        }
    }
}
