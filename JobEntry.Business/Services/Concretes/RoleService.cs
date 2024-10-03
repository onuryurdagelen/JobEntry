using AutoMapper;
using JobEntity.DataAccess.UnitOfWorks;
using JobEntry.Business.Utilities.Responses;
using JobEntry.Entity.DTOs.Role;
using JobEntry.Entity.DTOs.User;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Services.Concretes
{
    public class RoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<ServiceResponse<List<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.GetRepository<AppRole>().GetAllAsync();

            var mappedRoles = _mapper.Map<List<RoleDto>>(roles);

            return new ServiceResponse<List<RoleDto>>(true, mappedRoles);
        }
    }
}
