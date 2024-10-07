using AutoMapper;
using JobEntity.DataAccess.UnitOfWorks;
using JobEntry.Business.Helpers.Images;
using JobEntry.Business.Utilities.Responses;
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
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.GetRepository<AppUser>().GetAllAsync(includeProperties: x => x.Image);

            var mappedUsers = new List<UserDto>();

            foreach (var user in users) 
            {
                var roles = await _userManager.GetRolesAsync(user);
                mappedUsers.Add(new UserDto
                {
                    Id = user.Id,
                    EmailAddress = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    Image = user.Image,
                    Roles = roles
                });
            }

            return new ServiceResponse<List<UserDto>>(true, mappedUsers);
        }
    }
}
