using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.DTOs.Criterion;
using JobEntry.Entity.DTOs.Criterions;
using JobEntry.Entity.DTOs.Qualification;
using JobEntry.Entity.DTOs.Responsibility;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Job
{
    public class CreateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public decimal SalaryStart { get; set; }
        public decimal SalaryEnd { get; set; }
        public DateTime DateLine { get; set; }
      
        public Guid CompanyId { get; set; }
        public Guid WorkTypeId { get; set; }

        public Guid[] SelectedDrivingLicenseIds { get; set; }
        public Guid[] SelectedExperienceIds { get; set; }
        public Guid[] SelectedEducationLevelIds { get; set; }
        public Guid[] SelectedMilitaryStatusIds { get; set; }

        public CriterionListDto Criterions { get; set; } = new CriterionListDto();

        public QualificationDto? Qualification { get; set; }
        public ResponsibilityDto? Responsibility { get; set; }

        public List<QualificationDto> Qualifications { get; set; } //aranan nitelikler
        public List<ResponsibilityDto> Responsibilities { get; set; } //sorumluluklar


        public IList<CompanyDto>? Companies { get; set; }
        public IList<WorkType>? WorkTypes { get; set; }


    }
}
