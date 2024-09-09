

using Microsoft.AspNetCore.Http;

namespace Palmfit.Application.Dtos.User
{
    public class PhotoDto
    {
        public IFormFile? PalmfitImage { get; set; }
    }
}
