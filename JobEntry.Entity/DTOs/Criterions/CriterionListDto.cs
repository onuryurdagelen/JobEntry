using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Criterions
{
    public class CriterionListDto
    {
        public IList<Experience>? Experiences { get; set; }
        public IList<EducationLevel>? EducationLevels { get; set; }
        public IList<MilitaryStatus>? MilitaryStatuses { get; set; }
        public IList<DrivingLicense>? DrivingLicenses { get; set; }
    }
    }

