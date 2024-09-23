using AutoMapper;
using JobEntry.Entity.DTOs.Company;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.AutoMapper.Companies
{
    public class CompanyProfile:Profile
	{
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company,CreateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<CompanyDto, UpdateCompanyDto>().ReverseMap();
        }
    }
}
