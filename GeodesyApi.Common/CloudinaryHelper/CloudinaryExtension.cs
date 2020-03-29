using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace GeodesyApi.Common.CloudinaryHelper
{
    public class CloudinaryExtension
    {
        public static async Task<RawUploadResult> UploadAsync(Cloudinary cloudinary, IFormFile file)
        {
            byte[] submittedFile;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            submittedFile = memoryStream.ToArray();

            using var destinationStream = new MemoryStream(submittedFile);
            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(file.Name, destinationStream),
            };

            var result = await cloudinary.UploadAsync(uploadParams);

            return result;
        }

        public static async Task<ICollection<RawUploadResult>> UploadMultipleAsync(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            var filesRepository = new List<RawUploadResult>();

            foreach (var file in files)
            {
                byte[] submittedFile;

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                submittedFile = memoryStream.ToArray();

                using var destinationStream = new MemoryStream(submittedFile);
                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.Name, destinationStream),
                };

                var result = await cloudinary.UploadAsync(uploadParams);

                filesRepository.Add(result);
            }

            return filesRepository;
        }

    }
}
