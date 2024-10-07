using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Image
{
    public class UpdateImageDto
    {
        public Guid Id { get; set; }

        public string FileType { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
