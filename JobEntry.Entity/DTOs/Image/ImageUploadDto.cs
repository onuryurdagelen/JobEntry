using JobEntry.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Image
{
    public class ImageUploadDto
    {
        public string FileName { get; set; }
        public ImageType ImageType { get; set; }
        public string Message { get; set; }
    }
}
