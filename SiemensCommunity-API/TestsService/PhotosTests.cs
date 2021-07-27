using System;
using System.Collections.Generic;
using System.Linq;
using Service.Contracts;
using Service.Implementations;
using Service.Models;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Data.Contracts;
using NUnit.Framework;
using Microsoft.Extensions.Options;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;

namespace Service.Tests
{
    public class PhotosTests
    {
        private PhotoService photoService;
        private Mock<IPhotoService> photoServiceMock;
        private Mock<IPhotoRepository> photoRepository = new Mock<IPhotoRepository>();
        Account cloudinaryMock = new Account { 

        };
        Mock<ImageUploadResult> uploadResult = new Mock<ImageUploadResult>();
        Mock<IFormFile> testFile = new Mock<IFormFile>();
             
/*        private List<Data.Models.Photo> dataPhotos = new List<Data.Models.Photo> {
            new Data.Models.Photo { Id = 1, Url = "", PublicId = "", IsMain = false },
            new Data.Models.Photo { Id = 2, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false },
            new Data.Models.Photo { Id = 3, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false }
        };

        private List<Photo> photos = new List<Photo> {
                new Photo { Id = 1, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false },
                new Photo { Id = 2, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false },
                new Photo { Id = 3, Url = Guid.NewGuid().ToString(), PublicId = "", IsMain = false }
        };*/

        [SetUp]
        public void SetUp()
        {
            photoServiceMock = new Mock<IPhotoService>(MockBehavior.Strict);
        }

        [Test]
        public async Task UploadPhohoAsync_UploadPhoto()
        {
            photoServiceMock.Setup(p => p.UploadPhohoAsync(testFile.Object)).Returns(Task.FromResult(uploadResult.Object));

            var result = await photoService.UploadPhohoAsync(testFile.Object);

            Assert.IsNull(result.Error);
        }
    }
}
