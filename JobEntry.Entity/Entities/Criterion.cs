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
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<EducationLevel> EducationLevels { get; set; } = new List<EducationLevel>();
        public ICollection<MilitaryStatus> MilitaryStatuses { get; set; } = new List<MilitaryStatus>();
        public ICollection<DrivingLicense> DrivingLicenses { get; set; } = new List<DrivingLicense>();

    }
}
