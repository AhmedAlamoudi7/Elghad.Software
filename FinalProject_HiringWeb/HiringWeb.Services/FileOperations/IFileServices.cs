using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.FileOperations
{
    public interface IFileServices
    {
        Task<string> SaveFile(IFormFile File, string FolderName);
        void DeleteFile(string FileName);
    }
}
