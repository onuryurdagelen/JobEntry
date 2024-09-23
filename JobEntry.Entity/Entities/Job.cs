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
        public Job(string name,string description,string location,decimal salaryStart,decimal salaryEnd,DateTime dateline,Guid companyId)
        {
            Name = name;
            Description = description;  
            Location = location;
            SalaryStart = salaryStart;
            SalaryEnd = salaryEnd;
            DateLine = dateline;
            CompanyId = companyId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal SalaryStart { get; set; }
        public decimal SalaryEnd { get; set; }
  
        public DateTime DateLine { get; set; }

        public Qualification? Qualification { get; set; }
        public Responsibility? Responsibility { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        //Bir işe başvuran birden fazla aday kullanıcıları olabilir.
        public ICollection<Applicant> Applicants { get; set; } = new List<Applicant>(); 
    }
    
}
