using AutoMapper;
using JobEntity.DataAccess.UnitOfWorks;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Utilities.Responses;
using JobEntry.Entity.DTOs.Qualification;
using JobEntry.Entity.DTOs.Responsibility;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Services.Concretes
{
    public class CriterionService : ICriterionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CriterionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<QualificationDto>> AddQualificationAsync(QualificationDto model)
        {
            var qualification = _mapper.Map<Qualification>(model);
            await _unitOfWork.GetRepository<Qualification>().AddAsync(qualification);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<QualificationDto>(true, model);
        }

        public async Task<ServiceResponse<ResponsibilityDto>> AddResponsibilityAsync(ResponsibilityDto model)
        {
            var responsibility = _mapper.Map<Responsibility>(model);
            await _unitOfWork.GetRepository<Responsibility>().AddAsync(responsibility);
            await _unitOfWork.SaveChangesAsync(); 
            return new ServiceResponse<ResponsibilityDto>(true, model);
        }
        public async Task<ServiceResponse<QualificationDto>> UpdateQualification(QualificationDto model)
        {
            var qualification = _mapper.Map<Qualification>(model);
            _unitOfWork.GetRepository<Qualification>().Update(qualification);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<QualificationDto>(true, model);
        }

        public async Task<ServiceResponse<ResponsibilityDto>> UpdateResponsibility(ResponsibilityDto model)
        {
            var responsibility = _mapper.Map<Responsibility>(model);
            _unitOfWork.GetRepository<Responsibility>().Update(responsibility);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<ResponsibilityDto>(true, model);
        }

        public async Task<ServiceResponse<List<QualificationDto>>> DeleteQualification(string qId, string jobId)
        {
            var qualification = await _unitOfWork.GetRepository<Qualification>().GetAsync(predicate:x => x.Id == Guid.Parse(qId));   
            qualification.JobId = Guid.Parse(jobId);
            _unitOfWork.GetRepository<Qualification>().Delete(qualification);
            _unitOfWork.SaveChanges();
            var job = await _unitOfWork.GetRepository<Job>().GetAsync(predicate: x => x.Id == Guid.Parse(jobId),includeProperties:u => u.Qualifications);
            var restOfQualifications = _mapper.Map<List<QualificationDto>>(job.Qualifications);
            
            return new ServiceResponse<List<QualificationDto>> {Data = restOfQualifications, Success = true,Message = "Qualification successfully deleted!" };
        }

        public async Task<ServiceResponse<List<ResponsibilityDto>>> DeleteResponsibility(string rId, string jobId)
        {
            var responsibility = await _unitOfWork.GetRepository<Responsibility>().GetAsync(predicate: x => x.Id == Guid.Parse(rId));
            responsibility.JobId = Guid.Parse(jobId);
            _unitOfWork.GetRepository<Responsibility>().Delete(responsibility);
            _unitOfWork.SaveChanges();
            var job = await _unitOfWork.GetRepository<Job>().GetAsync(predicate: x => x.Id == Guid.Parse(jobId), includeProperties: u => u.Responsibilities);
            var restOfResponsibilities = _mapper.Map<List<ResponsibilityDto>>(job.Responsibilities);
            return new ServiceResponse<List<ResponsibilityDto>> {Data =restOfResponsibilities, Success = true, Message = "Responsibility successfully deleted!" };
        }

        public async Task<ServiceResponse<List<DrivingLicense>>> GetAllDrivingLicensesAsync()
        {
            var drivingLicenses = await _unitOfWork.GetRepository<DrivingLicense>().GetAllAsync();

            return new ServiceResponse<List<DrivingLicense>> { Data = drivingLicenses, StatusCode = 200, Success = true };
        }

        public async Task<ServiceResponse<List<EducationLevel>>> GetAllEducationLevelsAsync()
        {
            var educationLevels = await _unitOfWork.GetRepository<EducationLevel>().GetAllAsync();
            return new ServiceResponse<List<EducationLevel>> { Data = educationLevels, StatusCode = 200, Success = true };
        }

        public async Task<ServiceResponse<List<Experience>>> GetAllExperienceAsync()
        {
            var experiences = await _unitOfWork.GetRepository<Experience>().GetAllAsync();
            return new ServiceResponse<List<Experience>> { Data = experiences, StatusCode = 200, Success = true };
        }

        public async Task<ServiceResponse<List<MilitaryStatus>>> GetAllMilitaryStatusesAsync()
        {
            var militaryStatuses = await _unitOfWork.GetRepository<MilitaryStatus>().GetAllAsync();
            return new ServiceResponse<List<MilitaryStatus>> { Data = militaryStatuses, StatusCode = 200, Success = true };
        }
        public async Task<ServiceResponse<List<WorkType>>> GetAllWorkTypesAsync()
        {
            var workTypes = await _unitOfWork.GetRepository<WorkType>().GetAllAsync();
            return new ServiceResponse<List<WorkType>> { Data = workTypes, StatusCode = 200, Success = true };
        }

        public async Task<ServiceResponse<QualificationDto>> GetQualificationAsync(string qId, string jobId)
        {
            var qualification = await _unitOfWork.GetRepository<Qualification>().GetAsync(predicate: x => x.Id == Guid.Parse(qId));
            return new ServiceResponse<QualificationDto>(true, _mapper.Map<QualificationDto>(qualification));
        }

        public async Task<ServiceResponse<ResponsibilityDto>> GetResponsibilityAsync(string rId, string jobId)
        {
            var responsibility = await _unitOfWork.GetRepository<Responsibility>().GetAsync(predicate: x => x.Id == Guid.Parse(rId));
            return new ServiceResponse<ResponsibilityDto>(true, _mapper.Map<ResponsibilityDto>(responsibility));
        }
    }
}
