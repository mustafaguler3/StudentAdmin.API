using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentAdmin.API.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile formFile, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"Resources\Images",fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await formFile.CopyToAsync(fileStream);
            return GetServerRelativePath(fileName);
        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
