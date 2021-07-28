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
using SiemensCommunity;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Service.Tests
{
    public class PhotosTests
    {
        private PhotoService photoService;
        private Mock<IPhotoService> photoServiceMock;
        private Mock<IPhotoRepository> photoRepository = new Mock<IPhotoRepository>();
        Mock<ImageUploadResult> uploadResult = new Mock<ImageUploadResult>();
        IOptions<Service.Helpers.CloudinaryConfiguration> options = Options.Create(new Helpers.CloudinaryConfiguration() { CloudName = "db4zulf3p", ApiKey = "571223714477617", ApiSecret = "VxOGPDY7nfF_C0T_kllq824BkDY" });

        [SetUp]
        public void SetUp()
        {
            photoServiceMock = new Mock<IPhotoService>(MockBehavior.Strict);
            photoService = new PhotoService(options, new Mock<ILoggerFactory>().Object);
        }

    }
}
