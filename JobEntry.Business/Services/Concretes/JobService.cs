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
using Microsoft.EntityFrameworkCore;
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
            var jobs = await _unitOfWork.GetRepository<Job>().GetAllAsync(
                predicate:x => !x.IsDeleted,
                x => x.Company
                );
            var mappedJobs = _mapper.Map<List<JobDto>>(jobs);

            return new ServiceResponse<List<JobDto>>(true, mappedJobs);
        }
        public async Task<ServiceResponse<CreateJobDto>> CreateJobAsync(CreateJobDto model)
        {
            List<Experience> selectedExperiences = new List<Experience>();
            List<EducationLevel> selectedEducationLevels = new List<EducationLevel>();
            List<DrivingLicense> selectedDrivingLicenses = new List<DrivingLicense>();
            List<MilitaryStatus> selectedMilitaryStatuses = new List<MilitaryStatus>();
            var user = _user.GetLoggedInUserId();
            var mappedJob = _mapper.Map<Job>(model);
            if(model.SelectedExperienceIds.Any())
            {
                foreach (var experienceId in model.SelectedExperienceIds)
                {
                    Experience selectedExperience = await _unitOfWork.GetRepository<Experience>().GetAsync(predicate: x => x.Id == experienceId);
                    selectedExperiences.Add(selectedExperience);
                }

            }
            if (model.SelectedEducationLevelIds.Any())
            {
                foreach (var educationLevelId in model.SelectedEducationLevelIds)
                {
                    EducationLevel selectedEducationLevel = await _unitOfWork.GetRepository<EducationLevel>().GetAsync(predicate: x => x.Id == educationLevelId);
                    selectedEducationLevels.Add(selectedEducationLevel);
                }

            }
            if (model.SelectedDrivingLicenseIds.Any())
            {
                foreach (var drivingLicenseId in model.SelectedDrivingLicenseIds)
                {
                    DrivingLicense selectedDrivingLicense = await _unitOfWork.GetRepository<DrivingLicense>().GetAsync(predicate: x => x.Id == drivingLicenseId);
                    selectedDrivingLicenses.Add(selectedDrivingLicense);
                }

            }
            if (model.SelectedMilitaryStatusIds.Any())
            {
                foreach (var militaryStatusId in model.SelectedMilitaryStatusIds)
                {
                    MilitaryStatus selectedMilitaryStatus = await _unitOfWork.GetRepository<MilitaryStatus>().GetAsync(predicate: x => x.Id == militaryStatusId);
                    selectedMilitaryStatuses.Add(selectedMilitaryStatus);
                }

            }

            mappedJob.CreatedBy = _user.GetLoggedInEmailAddress();
            mappedJob.CreatedDate = DateTime.Now;

            mappedJob.Criterion = new Criterion();
            await _unitOfWork.GetRepository<Criterion>().AddAsync(mappedJob.Criterion);
            mappedJob.Criterion.EducationLevels = selectedEducationLevels;
            mappedJob.Criterion.MilitaryStatuses = selectedMilitaryStatuses;
            mappedJob.Criterion.DrivingLicenses = selectedDrivingLicenses;
            mappedJob.Criterion.Experiences = selectedExperiences;
            await _unitOfWork.GetRepository<Job>().AddAsync(mappedJob);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<CreateJobDto>(true, model);
        }

        public async Task<ServiceResponse<JobDto>> GetJobAsync(Guid id)
        {
            var job = await _unitOfWork.GetRepository<Job>()
                .GetAsync(
                tracking:true,
                predicate: x => x.Id == id,
                u => u.Criterion.Experiences,
                u => u.Criterion.EducationLevels,
                u => u.Criterion.MilitaryStatuses,
                u => u.Criterion.DrivingLicenses,
                u => u.Qualifications,
                u => u.Responsibilities
                );
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
