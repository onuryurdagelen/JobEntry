using JobEntry.Core.Entities;
using JobEntry.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class Image:BaseEntity
	{
        public Image()
        {
            
        }
        public Image(string fileName,string fileType,string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }



    }
}
