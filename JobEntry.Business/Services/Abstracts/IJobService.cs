using JobEntry.Business.Utilities.Responses;
using JobEntry.Entity.DTOs;
using JobEntry.Entity.DTOs.Job;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Services.Abstracts
{
    public interface IJobService
    {
        Task<ServiceResponse<List<JobDto>>> GetAllJobsAsync();
        Task<ServiceResponse<JobDto>> GetJobAsync(Guid id);
        Task<ServiceResponse<JobDto>> DeleteAsync(Guid id);
        Task<ServiceResponse<CreateJobDto>> CreateJobAsync(CreateJobDto model);
        Task<ServiceResponse<UpdateJobDto>> UpdateJobAsync(UpdateJobDto model);
    }
}
