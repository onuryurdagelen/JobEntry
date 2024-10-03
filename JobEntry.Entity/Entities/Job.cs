using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class Job: BaseEntity
	{
        public Job()
        {
            
        }
        public Job(string title,string description,string country,string province,string district,decimal salaryStart,decimal salaryEnd,DateTime dateline,Guid companyId)
        {
            Title = title;
            Description = description;
            Country = country;
            Province = province;
            District = district;
            SalaryStart = salaryStart;
            SalaryEnd = salaryEnd;
            DateLine = dateline;
            CompanyId = companyId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public decimal SalaryStart { get; set; }
        public decimal SalaryEnd { get; set; }
        public bool IsExperienced { get; set; } //deneyim süresi => Deneyimli - Deneyimsiz
        public bool IsDisabled { get; set; } //engelli ilanı

        public DateTime DateLine { get; set; }

        public Guid? WorkTypeId { get; set; }
        public WorkType WorkType { get; set; } // tam zamanlı(full time) - dönemsel(periodical) - yarı zamanlı(part time) - serbest zamanlı(free time)
        public Guid? WorkPreferenceId { get; set; } 
        public WorkPreference WorkPreference { get; set; } //iş yerinde(office) - uzaktan(remove) - hibrit(hybrid)

        public Guid? CriterionId { get; set; }
        public Criterion Criterion { get; set; } //aday kriterleri
        public Guid? JobLanguageId { get; set; }
        public JobLanguage JobLanguage { get; set; } //ilan dili
        public Guid? PositionId { get; set; }
        public Position Position { get; set; } //pozisyon
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; } //departman

        public Guid? PositionLevelId { get; set; }
        public PositionLevel PositionLevel { get; set; } //pozisyon seviyesi
        public Guid? SectorId { get; set; }
        public Sector Sector { get; set; } //sektör

        public List<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public List<Responsibility> Responsibilities { get; set; } = new List<Responsibility>();

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        //Bir işe başvuran birden fazla aday kullanıcıları olabilir.
        public ICollection<Applicant> Applicants { get; set; } = new List<Applicant>(); 
    }
    
    
}
