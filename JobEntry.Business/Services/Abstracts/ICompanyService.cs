using JobEntry.Business.Utilities.Responses;
using JobEntry.Entity.DTOs;
using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.DTOs.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Services.Abstracts
{
    public interface ICompanyService
	{
        Task<ServiceResponse<CompanyDto>> DeleteAsync(Guid id);
        Task<ServiceResponse<UpdateCompanyDto>> UpdateCompanyAsync(UpdateCompanyDto model);
        Task<ServiceResponse<CompanyDto>> GetCompanyAsync(Guid id);
        Task<ServiceResponse<CreateCompanyDto>> CreateCompanyAsync(CreateCompanyDto model);
        Task<ServiceResponse<List<CompanyDto>>> GetAllCompaniesAsync();
	}
}
