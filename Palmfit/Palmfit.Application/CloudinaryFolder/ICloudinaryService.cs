

using Microsoft.AspNetCore.Http;

namespace Palmfit.Application.CloudinaryFolder
{
    public interface ICloudinaryService
    {
        /// <summary>
        /// Uploads an image to Cloudinary.
        /// </summary>
        /// <param name="filePath">The local path of the file to be uploaded.</param>
        /// <returns>The URL of the uploaded image.</returns>
        Task<string> UploadImageAsync(IFormFile file);

        /// <summary>
        /// Deletes an image from Cloudinary.
        /// </summary>
        /// <param name="publicId">The public ID of the image to be deleted.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        //Task<bool> DeleteImageAsync(string publicId);

        /// <summary>
        /// Gets the URL of an image stored in Cloudinary.
        /// </summary>
        /// <param name="publicId">The public ID of the image.</param>
        /// <returns>The URL of the image.</returns>
        Task<byte[]> GetImageBytesAsync(string imageUrl);
    }
}
