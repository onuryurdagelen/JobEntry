using AutoMapper;
using JobEntry.Entity.DTOs.Qualification;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.AutoMapper.Qualifications
{
    public class QualificationProfile: Profile
    {
        public QualificationProfile()
        {
            CreateMap<Qualification, QualificationDto>().ReverseMap();
        }
    }
}
