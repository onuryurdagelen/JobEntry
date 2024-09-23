using JobEntry.Entity.DTOs.Auth;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace JobEntry.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class AuthController : BaseController
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<AppRole> _roleManager;
		public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
        public IActionResult Login()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.EmailAddress);
				if(user != null)
				{
					var result = await _signInManager.PasswordSignInAsync(user, model.Password,model.RememberMe ,false);

					if (result.Succeeded)
					{
						var roles = await _userManager.GetRolesAsync(user);
						var claims = new List<Claim>
						{
							new Claim("FullName",user.FullName),
							new Claim(ClaimTypes.Role,String.Join(", ",roles.ToArray()))
						};
						var existedClaims = await _userManager.GetClaimsAsync(user);
						if(!existedClaims.Any())
							await _userManager.AddClaimsAsync(user, claims);
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);

                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
					else ModelState.AddModelError(string.Empty, "Email address or password is wrong!");
                }
				else ModelState.AddModelError(string.Empty, "Email address or password is wrong!");

                return View();
            }
			return View();
		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home", new { Area = "" });
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(string m)
		{
			return View();
		}
		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ForgotPassword(string m)
		{
			return View();
		}
	}
}
