using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.Job
{
    public class UpdateJobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal SalaryStart { get; set; }
        public decimal SalaryEnd { get; set; }
        public DateTime DateLine { get; set; }
        public bool IsDeleted { get; set; }
        public Qualification? Qualification { get; set; }
        public Responsibility? Responsibility { get; set; }
        public Guid CompanyId { get; set; }
        public IList<CompanyDto>? Companies { get; set; }
    }
}
