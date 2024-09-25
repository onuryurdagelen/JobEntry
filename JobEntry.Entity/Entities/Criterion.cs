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
        public Guid? ExperienceId { get; set; }
        public Experience? Experience { get; set; }
        public Guid? EducationLevelId { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public Guid? MilitaryStatusId { get; set; }
        public MilitaryStatus? MilitaryStatus { get; set; }
        public Guid? DrivingLicenseId { get; set; }
        public DrivingLicense? DrivingLicense { get; set; }

    }
}
