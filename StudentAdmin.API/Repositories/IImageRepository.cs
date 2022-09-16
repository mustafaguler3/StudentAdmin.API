using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace StudentAdmin.API.Repositories
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile formFile,string fileName);
    }
}
