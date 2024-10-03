using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Qualification
{
    public class QualificationDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "{0} Boş geçilmemelidir!")]
        public string Description { get; set; } = null!;
        public Guid? JobId { get; set; }
    }
}
