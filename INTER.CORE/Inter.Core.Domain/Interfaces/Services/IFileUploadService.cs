using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Inter.Core.Domain.Interfaces.Services
{
    public interface IFileUploadService
    {
        Task<string> Upload(string path, string fileName, IFormFile file);

        void Delete(string path, string fileName);
    }
}
