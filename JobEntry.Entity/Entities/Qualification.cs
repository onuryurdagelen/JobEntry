using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class Qualification:BaseEntity
	{

        public Qualification()
        {
            
        }
        public Qualification(string description,Guid jobId)
        {
            Description = description;
            JobId = jobId;
        }

        public string Description { get; set; }

        public Guid JobId { get; set; }
        public Job Job { get; set; } = null!;
        public ICollection<QualificationDetail> QualificationDetails { get; set; } = new List<QualificationDetail>();
    }
}
