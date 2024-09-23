using AutoMapper.Execution;
using JobEntry.Business.Helpers.Paths;
using JobEntry.Entity.DTOs.Image;
using JobEntry.Entity.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string wwwroot;
        private const string imgFolder = "images";
        private const string userImagesFolder = "users";
        private const string companyImagesFolder = "companies";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            wwwroot = env.WebRootPath;
        }
        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        public async Task<ImageUploadDto> Upload(string name, IFormFile file,ImageType imageType, string? folderName = null)
        {
            folderName = imageType switch
            {
                ImageType.User => userImagesFolder,
                ImageType.Company => companyImagesFolder,
            };

            //önce dosya oluşturulmuş mu onu kontrol edilir.Oluşturulmamış ise oluşturulur.
            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");

            string oldFileName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);

            name = ReplaceInvalidChars(name);

            bool isValidFileName = PathValidation.ValidateFileName(name);

            if (!isValidFileName) name = PathValidation.CleanFileName(name);

            string newFileName = $"{name}_{DateTime.Now.Millisecond}{fileExtension}";

            string path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

            if (!PathValidation.ValidatePath(path)) path = PathValidation.CleanPath(path);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            return new ImageUploadDto
            {
                FileName = Path.Combine(folderName, newFileName),
                ImageType = imageType,
                Message = imageType switch
                {
                    ImageType.User => $"The user image named {newFileName} was successfully uplaoded!",
                    ImageType.Company => $"The company image named {newFileName} was successfully uplaoded"
                }
            };

        }
        public void Delete(string imageName)
        {
           string fileToDelete = Path.Combine(wwwroot,imgFolder,imageName);
            if(File.Exists(fileToDelete)) File.Delete(fileToDelete);
    
        }
    }
}
