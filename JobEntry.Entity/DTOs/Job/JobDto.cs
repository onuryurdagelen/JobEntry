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
    public class JobDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public decimal SalaryStart { get; set; }
        public decimal SalaryEnd { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? DeletedBy { get; set; }

        public DateTime DateLine { get; set; }

        public List<QualificationDto> Qualifications { get; set; } //aranan nitelikler
        public List<ResponsibilityDto> Responsibilities { get; set; } //sorumluluklar

        public Guid? CriterionId { get; set; }
        public JobEntry.Entity.Entities.Criterion Criterion { get; set; } //aday kriterleri//aday kriterleri

        public Guid CompanyId { get; set; }
        public Guid WorkTypeId { get; set; }
        public Guid WorkPreferenceId { get; set; }

        public JobEntry.Entity.Entities.Company Company { get; set; }

        //Bir işe başvuran birden fazla aday kullanıcıları olabilir.
        public ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();
    }
}
