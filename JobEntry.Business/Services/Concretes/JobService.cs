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
            if(model.SelectedExperienceIds is not null && model.SelectedExperienceIds.Any())
            {
                foreach (var experienceId in model.SelectedExperienceIds)
                {
                    Experience selectedExperience = await _unitOfWork.GetRepository<Experience>().GetAsync(predicate: x => x.Id == experienceId);
                    selectedExperiences.Add(selectedExperience);
                }

            }
            if (model.SelectedEducationLevelIds is not null && model.SelectedEducationLevelIds.Any())
            {
                foreach (var educationLevelId in model.SelectedEducationLevelIds)
                {
                    EducationLevel selectedEducationLevel = await _unitOfWork.GetRepository<EducationLevel>().GetAsync(predicate: x => x.Id == educationLevelId);
                    selectedEducationLevels.Add(selectedEducationLevel);
                }

            }
            if (model.SelectedDrivingLicenseIds is not null && model.SelectedDrivingLicenseIds.Any())
            {
                foreach (var drivingLicenseId in model.SelectedDrivingLicenseIds)
                {
                    DrivingLicense selectedDrivingLicense = await _unitOfWork.GetRepository<DrivingLicense>().GetAsync(predicate: x => x.Id == drivingLicenseId);
                    selectedDrivingLicenses.Add(selectedDrivingLicense);
                }

            }
            if (model.SelectedMilitaryStatusIds is not null && model.SelectedMilitaryStatusIds.Any())
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
            //mappedJob.Criterion.EducationLevels = selectedEducationLevels;
            //mappedJob.Criterion.MilitaryStatuses = selectedMilitaryStatuses;
            //mappedJob.Criterion.DrivingLicenses = selectedDrivingLicenses;
            //mappedJob.Criterion.Experiences = selectedExperiences;
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
                u => u.Criterion,
                u => u.Criterion.CriterionExperiences,
                u => u.Criterion.CriterionEducationLevels,
                u => u.Criterion.CriterionDrivingLicenses,
                u => u.Criterion.CriterionMilitaryStatuses,
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
            var updatedJob = await _unitOfWork.GetRepository<Job>()
                .GetAsync(
                tracking: false,
                predicate: x => x.Id == model.Id,
                u => u.Criterion,
               u => u.Criterion,
                u => u.Criterion.CriterionExperiences,
                u => u.Criterion.CriterionEducationLevels,
                u => u.Criterion.CriterionDrivingLicenses,
                u => u.Criterion.CriterionMilitaryStatuses,
                u => u.Qualifications,
                u => u.Responsibilities
                );

            List<Experience> selectedExperiences = new List<Experience>();
            List<EducationLevel> selectedEducationLevels = new List<EducationLevel>();
            List<DrivingLicense> selectedDrivingLicenses = new List<DrivingLicense>();
            List<MilitaryStatus> selectedMilitaryStatuses = new List<MilitaryStatus>();


            if (updatedJob.Criterion is not null) mappedJob.Criterion = updatedJob.Criterion;
            else mappedJob.Criterion = new Criterion();


            if (model.SelectedExperienceIds is not null && model.SelectedExperienceIds.Any())
            {
                foreach (var experienceId in model.SelectedExperienceIds)
                {
                    Experience selectedExperience = await _unitOfWork.GetRepository<Experience>().GetAsync(predicate: x => x.Id == experienceId);
                    selectedExperiences.Add(selectedExperience);
                    
                }

            }
            if (model.SelectedEducationLevelIds is not null && model.SelectedEducationLevelIds.Any())
            {
                foreach (var educationLevelId in model.SelectedEducationLevelIds)
                {
                    EducationLevel selectedEducationLevel = await _unitOfWork.GetRepository<EducationLevel>().GetAsync(predicate: x => x.Id == educationLevelId);
                    selectedEducationLevels.Add(selectedEducationLevel);
                }

            }
            if (model.SelectedDrivingLicenseIds is not null && model.SelectedDrivingLicenseIds.Any())
            {
                foreach (var drivingLicenseId in model.SelectedDrivingLicenseIds)
                {
                    DrivingLicense selectedDrivingLicense = await _unitOfWork.GetRepository<DrivingLicense>().GetAsync(predicate: x => x.Id == drivingLicenseId);
                    selectedDrivingLicenses.Add(selectedDrivingLicense);
                }

            }
            if (model.SelectedMilitaryStatusIds is not null && model.SelectedMilitaryStatusIds.Any())
            {
                foreach (var militaryStatusId in model.SelectedMilitaryStatusIds)
                {
                    MilitaryStatus selectedMilitaryStatus = await _unitOfWork.GetRepository<MilitaryStatus>().GetAsync(predicate: x => x.Id == militaryStatusId);
                    selectedMilitaryStatuses.Add(selectedMilitaryStatus);
                }

            }



            var excludedExperiences = updatedJob.Criterion is not null && updatedJob.Criterion.CriterionExperiences.Count > 0 ? selectedExperiences.Except(updatedJob.Criterion.CriterionExperiences.Select(x => x.Experience)).ToList() : selectedExperiences;
            var excludedEducationLevels = updatedJob.Criterion is not null && updatedJob.Criterion.CriterionEducationLevels.Count > 0 ? selectedEducationLevels.Except(updatedJob.Criterion.CriterionEducationLevels.Select(x => x.EducationLevel)).ToList() : selectedEducationLevels;
            List<DrivingLicense>? excludedDrivingLicenses = updatedJob.Criterion is not null && updatedJob.Criterion.CriterionDrivingLicenses.Count > 0 ? selectedDrivingLicenses.Except(updatedJob.Criterion.CriterionDrivingLicenses.Select(x => x.DrivingLicense)).ToList() : selectedDrivingLicenses;
            var excludedMilitaryStatuses = updatedJob.Criterion is not null && updatedJob.Criterion.CriterionMilitaryStatuses.Count > 0 ? selectedMilitaryStatuses.Except(updatedJob.Criterion.CriterionMilitaryStatuses.Select(x => x.MilitaryStatus)).ToList() : selectedMilitaryStatuses;

             mappedJob.Criterion.CriterionExperiences.ToList().ForEach(ce => _unitOfWork.GetRepository<CriterionExperience>().Delete(ce)); 
            mappedJob.Criterion.CriterionEducationLevels.ToList().ForEach(ce => _unitOfWork.GetRepository<CriterionEducationLevel>().Delete(ce)); 
            mappedJob.Criterion.CriterionDrivingLicenses.ToList().ForEach(ce => _unitOfWork.GetRepository<CriterionDrivingLicense>().Delete(ce)); 
            mappedJob.Criterion.CriterionMilitaryStatuses.ToList().ForEach(ce => _unitOfWork.GetRepository<CriterionMilitaryStatus>().Delete(ce));
            await _unitOfWork.SaveChangesAsync();
            excludedEducationLevels.ForEach(ee => mappedJob.Criterion.CriterionEducationLevels.Add(new CriterionEducationLevel {CriterionId = mappedJob.CriterionId ?? Guid.NewGuid(), EducationLevel = ee, EducationLevelId = ee.Id }));
            excludedExperiences.ForEach(ee => mappedJob.Criterion.CriterionExperiences.Add(new CriterionExperience { CriterionId = mappedJob.CriterionId ?? Guid.NewGuid(), Experience = ee, ExperienceId = ee.Id }));
            excludedDrivingLicenses.ForEach(ee => mappedJob.Criterion.CriterionDrivingLicenses.Add(new CriterionDrivingLicense { CriterionId = mappedJob.CriterionId ?? Guid.NewGuid(), DrivingLicense = ee, DrivingLicenseId = ee.Id }));
            excludedMilitaryStatuses.ForEach(ee => mappedJob.Criterion.CriterionMilitaryStatuses.Add(new CriterionMilitaryStatus { CriterionId = mappedJob.CriterionId ?? Guid.NewGuid(), MilitaryStatus = ee, MilitaryStatusId = ee.Id }));

            await _unitOfWork.GetRepository<CriterionEducationLevel>().AddRangeAsync(mappedJob.Criterion.CriterionEducationLevels.ToArray());
            await _unitOfWork.GetRepository<CriterionExperience>().AddRangeAsync(mappedJob.Criterion.CriterionExperiences.ToArray());
            await _unitOfWork.GetRepository<CriterionDrivingLicense>().AddRangeAsync(mappedJob.Criterion.CriterionDrivingLicenses.ToArray());
            await _unitOfWork.GetRepository<CriterionMilitaryStatus>().AddRangeAsync(mappedJob.Criterion.CriterionMilitaryStatuses.ToArray());

            if (updatedJob.Criterion is null) await _unitOfWork.GetRepository<Criterion>().AddAsync(mappedJob.Criterion);
            mappedJob.ModifiedBy = _user.GetLoggedInEmailAddress();
            mappedJob.ModifiedDate = DateTime.Now;   
            _unitOfWork.GetRepository<Job>().Update(mappedJob);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<UpdateJobDto>(true, model);
        }
    }
}
