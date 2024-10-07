using AutoMapper;
using JobEntry.Entity.DTOs.Role;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.AutoMapper.Roles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, AppRole>().ReverseMap();

        }
    }
}
