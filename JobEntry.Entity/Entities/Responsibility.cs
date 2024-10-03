using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class Responsibility:IBaseEntity
	{
        public Guid Id { get; set; }
        public Responsibility()
        {
            
        }
        public Responsibility(string description,Guid jobId)
        {
            Description = description;
            JobId = jobId;
        }


        public string Description { get; set; }
		public Guid JobId { get; set; }
		public Job Job { get; set; } = null!;

    }
}
