using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> UploadPhohoAsync(IFormFile file);
    }
}
