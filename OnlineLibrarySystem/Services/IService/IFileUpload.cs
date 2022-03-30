using Microsoft.AspNetCore.Components.Forms;

namespace OnlineLibrarySystem.Services.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string fileName);
    }
}
