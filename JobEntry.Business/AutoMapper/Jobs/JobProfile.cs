using AutoMapper;
using JobEntry.Entity.DTOs.Job;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.AutoMapper.Jobs
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobDto,Job>()
                .ReverseMap().ForMember(dest => dest.Location,opt => opt.MapFrom(src => $"{src.District}, {src.Province}, {src.Country}"));
            CreateMap<CreateJobDto,Job>().ReverseMap();
            CreateMap<UpdateJobDto,Job>().ReverseMap();
            CreateMap<JobDto,UpdateJobDto>().ReverseMap();
        }   
    }
}
