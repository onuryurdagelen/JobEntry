using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class CriterionExperience:IBaseEntity
    {
        public Guid CriterionId { get; set; }
        public Criterion Criterion { get; set; }
        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
