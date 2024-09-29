using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            //var folderPath = @"F:\FCAI\Route\ASP MVC\session 4\Assignment\Company.Web\wwwroot\images\";
            // 1- Get Folder Path
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            // 2- Get File Name
            var FileName = $"{Guid.NewGuid()}-{file.FileName}";

            // 3- Cobine FolderPath with FileName
            var FilePath = Path.Combine(FolderPath, FileName);

            using var FileStream = new FileStream(FilePath,FileMode.Create);

            file.CopyTo(FileStream);

            return FilePath;

        }
    }
}
