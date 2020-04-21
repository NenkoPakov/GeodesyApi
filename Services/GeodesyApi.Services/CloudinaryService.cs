using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        public Cloudinary Cloudinary { get; }

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.Cloudinary = cloudinary;
        }

        public virtual async Task<string> UploadAsync(IFormFile file)
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

            var result = await this.Cloudinary.UploadAsync(uploadParams);

            return result.Uri.AbsoluteUri;
        }

        // public static async Task<ICollection<string>> UploadMultipleAsync(ICollection<IFormFile> files)
        // {
        //     var filesRepository = new List<string>();
        //
        //     foreach (var file in files)
        //     {
        //         byte[] submittedFile;
        //
        //         using var memoryStream = new MemoryStream();
        //         await file.CopyToAsync(memoryStream);
        //         submittedFile = memoryStream.ToArray();
        //
        //         using var destinationStream = new MemoryStream(submittedFile);
        //         var uploadParams = new RawUploadParams()
        //         {
        //             File = new FileDescription(file.Name, destinationStream),
        //         };
        //
        //         var result = await Cloudinary.UploadAsync(uploadParams);
        //
        //         filesRepository.Add(result.Uri.AbsoluteUri);
        //     }
        //
        //     return filesRepository;
        // }
    }
}
