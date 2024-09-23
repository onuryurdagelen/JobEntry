using AutoMapper;
using JobEntity.DataAccess.UnitOfWorks;
using JobEntry.Business.Bases;
using JobEntry.Business.Extensions;
using JobEntry.Business.Helpers.Images;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Utilities.Responses;
using JobEntry.Business.Utilities.Statics;
using JobEntry.Entity.DTOs;
using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.DTOs.Image;
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
    public class CompanyService : ICompanyService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IImageHelper _imageHelper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _imageHelper = imageHelper;
        }

        public async Task<ServiceResponse<CreateCompanyDto>> CreateCompanyAsync(CreateCompanyDto model)
        {
            var user = _user.GetLoggedInUserId();
            var mappedCompany = _mapper.Map<Company>(model);
            mappedCompany.CreatedBy = _user.GetLoggedInEmailAddress();
            mappedCompany.CreatedDate = DateTime.Now;

            //upload image
            if(model.Photo is not null)
            {
                var imageUpload = await _imageHelper.Upload(model.Name, model.Photo, Entity.Enums.ImageType.Company);
                Image image = new Image(imageUpload.FileName,model.Photo.ContentType, _user.GetLoggedInEmailAddress());
                mappedCompany.Image = image;
                mappedCompany.Image.CreatedDate = DateTime.Now;
                mappedCompany.Image.CreatedBy = _user.GetLoggedInEmailAddress();
            }


            await _unitOfWork.GetRepository<Company>().AddAsync(mappedCompany);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<CreateCompanyDto>(true, model);
        }

        public async Task<ServiceResponse<List<CompanyDto>>> GetAllCompaniesAsync()
		{
			var companies = await _unitOfWork.GetRepository<Company>().GetAllAsync(predicate: x => !x.IsDeleted,includeProperties:x => x.Image);
			var mappedCompanies = _mapper.Map<List<CompanyDto>>(companies);

			
			return new ServiceResponse<List<CompanyDto>>(true, mappedCompanies);
		}
        public async Task<ServiceResponse<CompanyDto>> DeleteAsync(Guid id)
        {
            var deletedCompany = await _unitOfWork.GetRepository<Company>().GetByGuidAsync(id);
            if (!_user.IsLoggedInUserInRole(ApplicationRoles.SuperAdmin))
            {
                deletedCompany.IsDeleted = true;
                deletedCompany.DeletedBy = _user.GetLoggedInEmailAddress();
                deletedCompany.DeletedDate = DateTime.Now;
                _unitOfWork.GetRepository<Company>().Update(deletedCompany);
            }
            else _unitOfWork.GetRepository<Company>().Delete(deletedCompany);

            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<CompanyDto>{ Success = true,Data = _mapper.Map<CompanyDto>(deletedCompany) };
        }

        public async Task<ServiceResponse<UpdateCompanyDto>> UpdateCompanyAsync(UpdateCompanyDto model)
        {
            var company = await _unitOfWork.GetRepository<Company>().GetAsync(predicate:x => x.Id == model.Id,includeProperties:x => x.Image);

            if(model.Photo is not null) 
            {
                if(company.Image is not null) _imageHelper.Delete(company.Image.FileName);


                ImageUploadDto imageUploadDto = await _imageHelper.Upload(model.Name, model.Photo, Entity.Enums.ImageType.Company);
                company.Image.ModifiedDate = DateTime.Now;
                company.Image.ModifiedBy = _user.GetLoggedInEmailAddress();
                company.Image.FileName = imageUploadDto.FileName;
                company.Image.FileType = model.Photo.ContentType;
            }
            company.Name = model.Name;
            company.Description = model.Description;
            company.ModifiedBy = _user.GetLoggedInEmailAddress();
            company.ModifiedDate = DateTime.Now;
            
            _unitOfWork.GetRepository<Company>().Update(company);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResponse<UpdateCompanyDto>(true, model);
        }

        public async Task<ServiceResponse<CompanyDto>> GetCompanyAsync(Guid id)
        {
            var company = await _unitOfWork.GetRepository<Company>().GetAsync(predicate:x => x.Id == id,includeProperties:x => x.Image);
            var mappedCompanyDto = _mapper.Map<CompanyDto>(company);
            return new ServiceResponse<CompanyDto>(true, mappedCompanyDto);
        }
    }
}
