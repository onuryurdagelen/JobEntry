using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class ResponsibilityDetail: BaseEntity
	{
        public ResponsibilityDetail()
        {
            
        }
        public ResponsibilityDetail(string description,Guid responsibilityId)
        {
            Description = description;
            ResponsibilityId = responsibilityId;
        }
        public string Description { get; set; }
        public Guid ResponsibilityId { get; set; }
        public Responsibility Responsibility { get; set; } = null!;
    }
}
