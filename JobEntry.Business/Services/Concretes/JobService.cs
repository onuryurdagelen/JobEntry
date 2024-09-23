using AutoMapper;
using JobEntity.DataAccess.UnitOfWorks;
using JobEntry.Business.Extensions;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Utilities.Responses;
using JobEntry.Business.Utilities.Statics;
using JobEntry.Entity.DTOs;
using JobEntry.Entity.DTOs.Job;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Services.Concretes
{
    public class JobService:IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public JobService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<ServiceResponse<List<JobDto>>> GetAllJobsAsync()
        {
            var jobs = await _unitOfWork.GetRepository<Job>().GetAllAsync(x => !x.IsDeleted,includeProperties: x => x.Company);
            var mappedJobs = _mapper.Map<List<JobDto>>(jobs);

            return new ServiceResponse<List<JobDto>>(true, mappedJobs);
        }
        public async Task<ServiceResponse<CreateJobDto>> CreateJobAsync(CreateJobDto model)
        {
            var user = _user.GetLoggedInUserId();
            var mappedJob = _mapper.Map<Job>(model);
            mappedJob.CreatedBy = _user.GetLoggedInEmailAddress();
            mappedJob.CreatedDate = DateTime.Now;
            await _unitOfWork.GetRepository<Job>().AddAsync(mappedJob);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<CreateJobDto>(true, model);
        }

        public async Task<ServiceResponse<JobDto>> GetJobAsync(Guid id)
        {
            var job = await _unitOfWork.GetRepository<Job>().GetByGuidAsync(id);
            var mappedJobDto = _mapper.Map<JobDto>(job);
            return new ServiceResponse<JobDto>(true,mappedJobDto);
        }

        public async Task<ServiceResponse<JobDto>> DeleteAsync(Guid id)
        {
           var deletedJob = await _unitOfWork.GetRepository<Job>().GetByGuidAsync(id);
            if (!_user.IsLoggedInUserInRole(ApplicationRoles.SuperAdmin))
            {
                deletedJob.IsDeleted = true;
                deletedJob.DeletedBy = _user.GetLoggedInEmailAddress();
                deletedJob.DeletedDate = DateTime.Now;
                _unitOfWork.GetRepository<Job>().Update(deletedJob);
            }
            else _unitOfWork.GetRepository<Job>().Delete(deletedJob);

            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<JobDto> { Success = true,Data = _mapper.Map<JobDto>(deletedJob)};
        }

        public async Task<ServiceResponse<UpdateJobDto>> UpdateJobAsync(UpdateJobDto model)
        {
            var mappedJob = _mapper.Map<Job>(model);
            mappedJob.ModifiedBy = _user.GetLoggedInEmailAddress();
            mappedJob.ModifiedDate = DateTime.Now;   
            _unitOfWork.GetRepository<Job>().Update(mappedJob);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<UpdateJobDto>(true, model);
        }
    }
}
