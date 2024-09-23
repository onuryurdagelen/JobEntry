using AutoMapper;
using FluentValidation;
using JobEntry.Business.Extensions;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Utilities.Statics;
using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.DTOs.Job;
using JobEntry.Entity.Entities;
using JobEntry.Web.NotifyMessages;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace JobEntry.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobController : BaseController
    {
        private readonly IJobService _jobService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly IValidator<Job> _validator;
        private readonly IToastNotification _toastNotification;
        public JobController(IJobService jobService, ICompanyService companyService, IMapper mapper, IValidator<Job> validator, IToastNotification toastNotification)
        {
            _jobService = jobService;
            _companyService = companyService;
            _mapper = mapper;
            _validator = validator;
            _toastNotification = toastNotification;
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
            return View(new CreateJobDto { Companies = result.Data });
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateJobDto model)
        {
            var result = await _validator.ValidateAsync(_mapper.Map<Job>(model));

            if(!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var getAllCompaniesResponse = await _companyService.GetAllCompaniesAsync();
                model.Companies = getAllCompaniesResponse.Data;
                return View(model);
            }

            var createdJobresponse = await _jobService.CreateJobAsync(model);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Create(model.Name));
            return RedirectToAction("Index", "Job", new { Area = "Admin" });
           
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
           var response =  await _jobService.GetJobAsync(Guid.Parse(id));
           var mappedJob = _mapper.Map<UpdateJobDto>(response.Data);
           var companiesData= await _companyService.GetAllCompaniesAsync();
           mappedJob.Companies = companiesData.Data;
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
                model.Companies = getAllCompaniesResponse.Data;
                return View(model);

            }
            var response = await _jobService.UpdateJobAsync(model);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Update(model.Name));
            return RedirectToAction("Index", "Job", new { Area = "Admin" });
           
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteResponse =  await _jobService.DeleteAsync(Guid.Parse(id));
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Delete(deleteResponse.Data.Name));
            return RedirectToAction("Index", "Job", new { Area = "Admin" });
        }
        


    }
}
