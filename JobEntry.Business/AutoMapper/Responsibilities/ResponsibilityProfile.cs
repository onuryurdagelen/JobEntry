using AutoMapper;
using JobEntry.Entity.DTOs.Responsibility;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.AutoMapper.Responsibilities
{
    public class ResponsibilityProfile:Profile
    {
        public ResponsibilityProfile()
        {
            CreateMap<Responsibility, ResponsibilityDto>().ReverseMap();
        }
    }
}
