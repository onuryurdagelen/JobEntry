using JobEntry.Entity.DTOs.Image;
using JobEntry.Entity.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadDto> Upload(string name,IFormFile file,ImageType imageType,string? folderName = null);
        void Delete(string imageName);
    }
}
