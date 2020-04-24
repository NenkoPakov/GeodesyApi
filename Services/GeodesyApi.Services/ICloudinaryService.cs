using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file);

        Task<ICollection<string>> UploadMultipleAsync(ICollection<IFormFile> files);

    }
}
