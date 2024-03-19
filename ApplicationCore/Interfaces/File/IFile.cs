using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationCore.Interfaces.Email
{
    public interface IFile
    {
        string UploadFile(IFormFile formFile,string path);
        void RemoveFile(string path, string FileName);

        
    }
}