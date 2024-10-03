using JobEntry.Business.Utilities.Responses;
using JobEntry.Entity.DTOs.Qualification;
using JobEntry.Entity.DTOs.Responsibility;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Services.Abstracts
{
    public interface ICriterionService
    {
        Task<ServiceResponse<List<Experience>>> GetAllExperienceAsync();
        Task<ServiceResponse<List<DrivingLicense>>> GetAllDrivingLicensesAsync();
        Task<ServiceResponse<List<EducationLevel>>> GetAllEducationLevelsAsync();
        Task<ServiceResponse<List<MilitaryStatus>>> GetAllMilitaryStatusesAsync();
        Task<ServiceResponse<List<WorkType>>> GetAllWorkTypesAsync();
        Task<ServiceResponse<List<QualificationDto>>> DeleteQualification(string qId, string jobId);
        Task<ServiceResponse<List<ResponsibilityDto>>> DeleteResponsibility(string rId, string jobId);
        Task<ServiceResponse<QualificationDto>> AddQualificationAsync(QualificationDto model);
        Task<ServiceResponse<ResponsibilityDto>> AddResponsibilityAsync(ResponsibilityDto model);

        Task<ServiceResponse<QualificationDto>> UpdateQualification(QualificationDto model);
        Task<ServiceResponse<ResponsibilityDto>> UpdateResponsibility(ResponsibilityDto model);
        Task<ServiceResponse<QualificationDto>> GetQualificationAsync(string qId, string jobId);
        Task<ServiceResponse<ResponsibilityDto>> GetResponsibilityAsync(string rId, string jobId);
    }
}
