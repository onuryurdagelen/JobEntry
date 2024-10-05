using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Criterions
{
    public class CriterionDto
    {
        public Guid[] SelectedExperienceIds { get; set; }
        public Guid[] SelectedDrivingLicenseIds { get; set; }
        public Guid[] SelectedEducationLevelIds { get; set; }
        public Guid[] SelectedMilitaryStatusIds { get; set; }

    }
}
