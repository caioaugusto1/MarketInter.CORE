using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Inter.Core.App.Intefaces
{
    public interface IFileUploadAppService
    {
        Task<string> Upload(string path, string fileName, IFormFile file);

        void Delete(string path, string fileName);
    }
}
