using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class CriterionEducationLevel : IBaseEntity
    {
        public Guid CriterionId { get; set; }
        public Criterion Criterion { get; set; }
        public Guid EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
    }
}
