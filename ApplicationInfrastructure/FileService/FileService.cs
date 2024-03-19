using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Email;
using Microsoft.AspNetCore.Http;

namespace ApplicationInfrastructure.FileService
{
    public class FileService : IFile
    {
        public void RemoveFile(string path, string fileName)
        {
            string fullPath = Path.Combine(path, fileName);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
        public string UploadFile(IFormFile formFile, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var FileName = Path.GetExtension(formFile.FileName);
            var fullPath = Path.Combine(path, FileName);
            using var fileStream = new FileStream(fullPath, FileMode.Create);
            formFile.CopyTo(fileStream);
            return FileName;
        }
    }
}