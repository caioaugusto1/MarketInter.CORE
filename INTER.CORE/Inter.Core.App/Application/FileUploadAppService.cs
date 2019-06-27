using Inter.Core.App.Intefaces;
using Inter.Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Inter.Core.App.Application
{
    public class FileUploadAppService : IFileUploadAppService
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadAppService(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public void Delete(string path, string fileName)
        {
            _fileUploadService.Delete(path, fileName);
        }

        public Task<string> Upload(string path, string fileName, IFormFile file)
        {
            return _fileUploadService.Upload(path, fileName, file);
        }
    }
}
