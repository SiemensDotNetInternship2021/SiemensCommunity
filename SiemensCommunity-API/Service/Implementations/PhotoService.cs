using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common;
using Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger _logger;
        private readonly ILogService _logService;
        private readonly IPhotoRepository _photoRepository;
        private PhotoAdapter _photoAdapter = new PhotoAdapter();

        public PhotoService(IOptions<Service.Helpers.CloudinaryConfiguration> config, ILoggerFactory logger, ILogService logService, IPhotoRepository photoRepository)
        {
            _logger = logger.CreateLogger("PhotoService");
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
            _logService = logService;
            _photoRepository = photoRepository;
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
                    await _logService.SaveAsync(LogLevel.Information, MyLogEvents.UploadItem, "Image uploaded successfully.", Environment.StackTrace);
                }
                catch (Exception ex)
                {
                    _logger.LogError(MyLogEvents.ErrorUploadItem, "Error upload image with message " + ex.Message);
                    await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ErrorUploadItem, ex.Message, ex.StackTrace);
                }
            }
            return uploadResult;
        }

        public async Task<Photo> SavePhoto(IFormFile file)
        {
            var image = new Photo();

            var result = await UploadPhotoAsync(file);
            if (result.Error != null)
            {
                _logger.LogError(MyLogEvents.UploadItem, "Error while uploading photo: {error}", result.Error);
                await _logService.SaveAsync(LogLevel.Information, MyLogEvents.UpdateItem, result.Error.ToString(), Environment.StackTrace);
            }

            image.Url = result.SecureUrl.AbsoluteUri;
            image.PublicId = result.PublicId;
            image.IsMain = false;
            var returnedPhoto = new Photo();    

            try
            {
                var adaptedPhoto = _photoAdapter.Adapt(image);
                var photoInDb = await _photoRepository.AddAsync(adaptedPhoto);
                returnedPhoto = _photoAdapter.Adapt(photoInDb);
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.InsertItem, "Error while trying to insert image in db with message " + ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.InsertItem, ex.Message, ex.StackTrace);
            }

            return returnedPhoto;
        }
    }
}
