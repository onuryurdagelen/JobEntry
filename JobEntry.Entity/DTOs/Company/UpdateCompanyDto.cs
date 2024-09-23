using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Company
{
    public class UpdateCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JobEntry.Entity.Entities.Image? Image { get; set; }
        [Display(Name = "Uploaded Image")]
        public IFormFile? Photo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
