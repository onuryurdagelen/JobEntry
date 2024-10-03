using AutoMapper;
using FluentValidation;
using JobEntry.Business.Extensions;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Utilities.Statics;
using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.DTOs.Job;
using JobEntry.Entity.DTOs.Qualification;
using JobEntry.Entity.DTOs.Responsibility;
using JobEntry.Entity.Entities;
using JobEntry.Web.NotifyMessages;
using JobEntry.Web.Results;
using JobEntry.Web.Services;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Cryptography;
using System.Text.Json;

namespace JobEntry.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobController : BaseController
    {
        private readonly IJobService _jobService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly IValidator<Job> _validator;
        private readonly IValidator<Qualification> _validatorQ;
        private readonly IValidator<Responsibility> _validatorR;
        private readonly ICriterionService _criterionService;
        private readonly IToastNotification _toastNotification;
        public JobController(IJobService jobService, ICompanyService companyService, IMapper mapper, IValidator<Job> validator, IValidator<Qualification> validatorQ, IToastNotification toastNotification, ICriterionService criterionService, IValidator<Responsibility> validatorR)
        {
            _jobService = jobService;
            _companyService = companyService;
            _mapper = mapper;
            _validator = validator;
            _toastNotification = toastNotification;
            _criterionService = criterionService;
            _validatorQ = validatorQ;
            _validatorR = validatorR;
        }
        public async Task<IActionResult> Index()
        {
           var result =  await _jobService.GetAllJobsAsync();
            return View(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _companyService.GetAllCompaniesAsync();
            var drivingLicensesResponse = await _criterionService.GetAllDrivingLicensesAsync();
            var educationLevelsResponse = await _criterionService.GetAllEducationLevelsAsync();
            var militaryStatusesResponse = await _criterionService.GetAllMilitaryStatusesAsync();
            var experiencesResponse = await _criterionService.GetAllExperienceAsync();
            var workTypes = await _criterionService.GetAllWorkTypesAsync();
            var model = new CreateJobDto
            {
                Companies = result.Data,
                WorkTypes = workTypes.Data,
                Criterions =
                {
                    DrivingLicenses = drivingLicensesResponse.Data,
                    EducationLevels = educationLevelsResponse.Data,
                    MilitaryStatuses = militaryStatusesResponse.Data,
                    Experiences = experiencesResponse.Data
                },
                
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateJobDto model)
        {
            var result = await _validator.ValidateAsync(_mapper.Map<Job>(model));

            if(!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var getAllCompaniesResponse = await _companyService.GetAllCompaniesAsync();
                var drivingLicensesResponse = await _criterionService.GetAllDrivingLicensesAsync();
                var educationLevelsResponse = await _criterionService.GetAllEducationLevelsAsync();
                var militaryStatusesResponse = await _criterionService.GetAllMilitaryStatusesAsync();
                var experiencesResponse = await _criterionService.GetAllExperienceAsync();
                var workTypes = await _criterionService.GetAllWorkTypesAsync();
                model.WorkTypes = workTypes.Data;
                model.Companies = getAllCompaniesResponse.Data;
                model.Criterions.EducationLevels = educationLevelsResponse.Data;
                model.Criterions.Experiences = experiencesResponse.Data;
                model.Criterions.MilitaryStatuses = militaryStatusesResponse.Data; 
                model.Criterions.DrivingLicenses = drivingLicensesResponse.Data;
                
               
                return View(model);
            }

            var createdJobresponse = await _jobService.CreateJobAsync(model);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Create(model.Title));
            return RedirectToAction("Index", "Job", new { Area = "Admin" });
           
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
           var response =  await _jobService.GetJobAsync(Guid.Parse(id));
           var mappedJob = _mapper.Map<UpdateJobDto>(response.Data);
           if(response.Data.Criterion is not null)
            {
                mappedJob.SelectedMilitaryStatusIds = response.Data.Criterion.MilitaryStatuses.Select(x => x.Id).ToArray();
                mappedJob.SelectedDrivingLicenseIds = response.Data.Criterion.DrivingLicenses.Select(x => x.Id).ToArray();
                mappedJob.SelectedEducationLevelIds = response.Data.Criterion.EducationLevels.Select(x => x.Id).ToArray();
                mappedJob.SelectedExperienceIds = response.Data.Criterion.Experiences.Select(x => x.Id).ToArray();
            }
           var companiesData= await _companyService.GetAllCompaniesAsync();
           var drivingLicensesResponse = await _criterionService.GetAllDrivingLicensesAsync();
           var educationLevelsResponse = await _criterionService.GetAllEducationLevelsAsync();
           var militaryStatusesResponse = await _criterionService.GetAllMilitaryStatusesAsync();
           var experiencesResponse = await _criterionService.GetAllExperienceAsync();
           var workTypes = await _criterionService.GetAllWorkTypesAsync();
           mappedJob.WorkTypes = workTypes.Data;
           mappedJob.Companies = companiesData.Data;
           mappedJob.Criterions.EducationLevels = educationLevelsResponse.Data;
           mappedJob.Criterions.Experiences = experiencesResponse.Data;
           mappedJob.Criterions.MilitaryStatuses = militaryStatusesResponse.Data;
           mappedJob.Criterions.DrivingLicenses = drivingLicensesResponse.Data;

            return View(mappedJob);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateJobDto model)
        {
            var result = await _validator.ValidateAsync(_mapper.Map<Job>(model));
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var getAllCompaniesResponse = await _companyService.GetAllCompaniesAsync();
                var getAllWorkTypesResponse = await _criterionService.GetAllWorkTypesAsync();
                model.Companies = getAllCompaniesResponse.Data;
                model.WorkTypes = getAllWorkTypesResponse.Data;
                return View(model);

            }
            var response = await _jobService.UpdateJobAsync(model);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Update(model.Title));
            return RedirectToAction("Index", "Job", new { Area = "Admin" });
           
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteResponse =  await _jobService.DeleteAsync(Guid.Parse(id));
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Delete(deleteResponse.Data.Title));
            return RedirectToAction("Index", "Job", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteQualification(string qId,string jobId)
        {
            await _criterionService.DeleteQualification(qId, jobId);
            return RedirectToAction("Edit", "Job", new { Area = "Admin", id = jobId });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQualificationWithAjax(string qId, string jobId)
        {
            var response = await _criterionService.DeleteQualification(qId, jobId);
            return new CustomResult(response);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteResponsibility(string rId, string jobId)
        {
            await _criterionService.DeleteResponsibility(rId, jobId);
            return RedirectToAction("Edit", "Job", new { Area ="Admin", id = jobId });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteResponsibilityWithAjax(string rId, string jobId)
        {
            var response = await _criterionService.DeleteResponsibility(rId, jobId);
            return new CustomResult(response);
        }
       
        [HttpGet]
        public IActionResult AddQualificationPartial(string jobId)
        {
            return PartialView("_QualificationAddPartial",new QualificationDto {JobId = Guid.Parse(jobId) });
        }
        [HttpGet]
        public IActionResult AddResponsibilityPartial(string jobId)
        {
            return PartialView("_ResponsibilityAddPartial", new ResponsibilityDto { JobId = Guid.Parse(jobId) });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateQualificationPartial(string qId,string jobId)
        {
            var response = await _criterionService.GetQualificationAsync(qId,jobId);
            return PartialView("_QualificationUpdatePartial", new QualificationDto { Id = response.Data.Id,JobId = response.Data.JobId,Description = response.Data.Description  });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateResponsibilityPartial(string rId,string jobId)
        {
            var response = await _criterionService.GetResponsibilityAsync(rId,jobId);
            return PartialView("_ResponsibilityUpdatePartial", new ResponsibilityDto { Id = response.Data.Id, JobId = response.Data.JobId, Description = response.Data.Description });
        }
        [HttpPost]
        public async Task<IActionResult> AddQualificationWithAjax(QualificationDto model)
        {
            var result = await _validatorQ.ValidateAsync(_mapper.Map<Qualification>(model));
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var viewWithErrorModel = await this.RenderViewToStringAsync("_QualificationAddPartial", model);
                return new CustomResult(new { view = viewWithErrorModel,success = false });
            }
            model.Id = Guid.NewGuid();
            var respponse = await _criterionService.AddQualificationAsync(model);
            var view = await this.RenderViewToStringAsync("_QualificationAddPartial",model);
            return new CustomResult(new {qualification = respponse.Data, view = view,success = true });

           
        }
        [HttpPost]
        public async Task<IActionResult> AddResponsibilityWithAjax(ResponsibilityDto model)
        {
            var result = await _validatorR.ValidateAsync(_mapper.Map<Responsibility>(model));
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var viewWithErrorModel = await this.RenderViewToStringAsync("_ResponsibilityAddPartial", model);
                return new CustomResult(new { view = viewWithErrorModel, success = false });
            }
            model.Id = Guid.NewGuid();
            var respponse = await _criterionService.AddResponsibilityAsync(model);
            var view = await this.RenderViewToStringAsync("_ResponsibilityAddPartial", model);
            return new CustomResult(new { responsibility = respponse.Data, view = view, success = true });


        }
        [HttpPost]
        public async Task<IActionResult> AddResponsibility(ResponsibilityDto model)
        {
            if (!ModelState.IsValid)
            {
                // Re-render the partial or full view with the ModelState errors
                var renderedView = this.RenderViewToStringAsync("_ResponsibilityAddPartial", model);
                return Json(new { success = false, view = renderedView });
            }

            // If valid, proceed with the success logic
            return Json(new { success = true, message = "Form submitted successfully!" });
        }

    }
}
