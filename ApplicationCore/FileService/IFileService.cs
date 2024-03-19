using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationCore.FileService
{
    public interface IFileService
    {
        string Upload(IFormFile formFile, string path);
    }
}