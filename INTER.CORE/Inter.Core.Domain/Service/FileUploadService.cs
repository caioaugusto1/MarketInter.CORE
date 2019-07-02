using Inter.Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Service
{
    public class FileUploadService : IFileUploadService
    {
        public void Delete(string path, string fileName)
        {
            var pathFile = Path.Combine(path,
                       fileName);

            if (File.Exists(pathFile))
                File.Delete(pathFile);
        }

        public async Task<string> Upload(string path, string fileName, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            string name = string.Empty;

            if (string.IsNullOrWhiteSpace(fileName))
                name = Guid.NewGuid().ToString() + ".pdf";
            else
                name = fileName;

            var pathCombine = Path.Combine(path, name);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (var stream = new FileStream(pathCombine, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return name;
        }
    }
}
