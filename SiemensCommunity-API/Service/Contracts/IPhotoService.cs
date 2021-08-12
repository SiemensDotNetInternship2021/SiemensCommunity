using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Service.Models;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> UploadPhotoAsync(IFormFile file);
        public Task<Photo> SavePhoto(IFormFile file);
    }
}
