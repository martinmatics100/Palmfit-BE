using Palmfit.Application.CloudinaryFolder;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using Palmfit.Application.Dtos.CloudinaryFolder;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Palmfit.Common.CloudinaryFolder
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySetting> config)
        {
            var account = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
        );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Transformation = new Transformation().Quality("auto").FetchFormat("auto")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
