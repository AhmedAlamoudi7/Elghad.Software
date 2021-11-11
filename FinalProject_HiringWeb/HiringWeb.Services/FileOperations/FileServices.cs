using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.FileOperations
{
    public class FileServices : IFileServices
    {
        private readonly IWebHostEnvironment _env;

        public FileServices(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveFile(IFormFile File, string FolderName)
        {
            string FileName = string.Empty;
            if (File != null && File.Length > 0)
            {
                var MainPath = Path.Combine(_env.WebRootPath, FolderName);
                 FileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(File.FileName);
                await using var FileStream = new FileStream(Path.Combine(MainPath, FileName), FileMode.Create);
                await File.CopyToAsync(FileStream);
            }

            return FileName;
        }

        public void DeleteFile(string FileName)
        {
            var MainPath = Path.Combine(_env.WebRootPath, "AllFiles");
            File.Delete(Path.Combine(MainPath, FileName));
        }
    }
}
