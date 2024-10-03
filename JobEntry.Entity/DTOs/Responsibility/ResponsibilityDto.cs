using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Responsibility
{
    public class ResponsibilityDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public Guid? JobId { get; set; }


    }
}
