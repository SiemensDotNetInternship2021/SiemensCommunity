using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Contracts;
using System;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger _logger;

        public PhotoService(IOptions<Service.Helpers.CloudinaryConfiguration> config, ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("PhotoService");
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation()
                                                .Height(500)
                                                .Width(500)
                                                .Crop("fill")
                                                .Gravity("face")
                };
                try
                {
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    _logger.LogInformation(MyLogEvents.UpdateItem, "Image upload.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(MyLogEvents.ErrorUploadItem, "Error upload image with message " + ex.Message);
                }
            }
            return uploadResult;
        }
    }
}
