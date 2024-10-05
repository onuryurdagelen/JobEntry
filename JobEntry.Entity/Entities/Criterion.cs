using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Criterion:IBaseEntity
    {
        public Guid Id { get; set; }
        public ICollection<CriterionDrivingLicense> CriterionDrivingLicenses { get; set; } = new List<CriterionDrivingLicense>();
        public ICollection<CriterionEducationLevel> CriterionEducationLevels { get; set; } = new List<CriterionEducationLevel>();
        public ICollection<CriterionExperience> CriterionExperiences { get; set; } = new List<CriterionExperience>();
        public ICollection<CriterionMilitaryStatus> CriterionMilitaryStatuses { get; set; } = new List<CriterionMilitaryStatus>();


    }
}
