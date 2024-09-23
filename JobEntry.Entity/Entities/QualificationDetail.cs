using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class QualificationDetail:BaseEntity
	{
        public QualificationDetail()
        {
            
        }
        public QualificationDetail(string description,Guid qualificationId)
        {
            Description = description;
            QualificationId = qualificationId;
        }
        public string Description { get; set; }
        public Guid QualificationId { get; set; }
        public Qualification Qualification { get; set; } = null!;
    }
}
