using AutoMapper;
using FluentValidation;
using JobEntry.Business.Extensions;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Services.Concretes;
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
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly IValidator<Company> _validator;
        private readonly IToastNotification _toastNotification;

        public CompanyController(ICompanyService companyService, IMapper mapper, IToastNotification toastNotification, IValidator<Company> validator)
        {
            _companyService = companyService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _companyService.GetAllCompaniesAsync();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCompanyDto model)
        {
            var result = await _validator.ValidateAsync(_mapper.Map<Company>(model));
            if (!result.IsValid) 
            {
                result.AddToModelState(this.ModelState);
                return View(model);
            
            } 
            var response = await _companyService.CreateCompanyAsync(model);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Create(model.Name));
            return RedirectToAction("Index", "Company", new { Area = "Admin" });
          
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var response = await _companyService.GetCompanyAsync(Guid.Parse(id));
            var mappedCompany = _mapper.Map<UpdateCompanyDto>(response.Data);
            return View(mappedCompany);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCompanyDto model)
        {
            var result = await _validator.ValidateAsync(_mapper.Map<Company>(model));
            if (!result.IsValid) 
            {
                result.AddToModelState(this.ModelState);
                return View(model);
            }
            var response = await _companyService.UpdateCompanyAsync(model);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Update(model.Name));
            return RedirectToAction("Index", "Company", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
           var deleteResponse = await _companyService.DeleteAsync(Guid.Parse(id));
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Job.Delete(deleteResponse.Data.Name));
            return RedirectToAction("Index", "Company", new { Area = "Admin" });
        }
    }
}
