using System;
using Data.Models;
using Data.Contracts;
using Data.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace Data.Tests
{
    public class PhotoTests
    {

        //system under test
        private PhotoRepository repository;
        //mock
        private Mock<IPhotoRepository> photoRepositoryMock;
        private ProjectDbContext dbContext;
        private string photoUrl = Guid.NewGuid().ToString();
        private string publicId = Guid.NewGuid().ToString();
        DbContextOptions<ProjectDbContext> options = new DbContextOptionsBuilder<ProjectDbContext>()
                                                             .UseInMemoryDatabase(databaseName: "SiemensCommunityTests")
                                                             .Options;
        private List<Photo> photos = new List<Photo>()
        {
            new Photo { Id = 1, Url = "", PublicId = "", IsMain = false },
            new Photo { Id = 2, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false },
            new Photo { Id = 3, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false }
        };

        [SetUp]
        public void Setup()
        {
            

            using (var context = new ProjectDbContext(options))
            {
                context.Photos.Add(new Photo { Id = 1, Url = photoUrl, PublicId = publicId, IsMain = false });
                context.Photos.Add(new Photo { Id = 2, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false });
                context.Photos.Add(new Photo { Id = 3, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false });
                context.SaveChanges();
            }

            dbContext = new ProjectDbContext(options);
            photoRepositoryMock = new Mock<IPhotoRepository>();
            repository = new PhotoRepository(dbContext);
        }

        [Test]
        public async Task GetPhotos_ShouldReturnListOfPhotos()
        {
            photoRepositoryMock.Setup(p => p.GetAsync()).ReturnsAsync(photos);

            var result = await repository.GetAsync();
                    
            Assert.IsInstanceOf<List<Photo>>(result);
            Assert.AreEqual(result.Count(),3);
        }

        [Test]
        public async Task FindByURL_ShouldReturnPhoto()
        {
            Photo photo = new Photo() { Id = 1, Url = photoUrl, PublicId = publicId,  IsMain = false  };
            photoRepositoryMock.Setup(p => p.FindByURL(photoUrl.ToString())).ReturnsAsync(photo);

            var expected = await repository.FindByURL(photoUrl);

            Assert.AreEqual(expected.Id, photo.Id);
            Assert.AreEqual(expected.Url, photo.Url);
            Assert.AreEqual(expected.PublicId, photo.PublicId);
            Assert.AreEqual(expected.IsMain, photo.IsMain);
        }

        [Test]
        public async Task FindByURL_ShouldReturnNull()
        {
            Photo photo = new Photo { Id = 1, Url = photoUrl, PublicId = Guid.NewGuid().ToString(), IsMain = false};
            photoRepositoryMock.Setup(p => p.FindByURL(photoUrl.ToString())).ReturnsAsync(photo);

            var expected = await repository.FindByURL(photoUrl);

            Assert.IsNull(expected);
        }
    }
}
