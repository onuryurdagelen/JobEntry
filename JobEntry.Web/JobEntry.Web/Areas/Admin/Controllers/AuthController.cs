using JobEntry.Entity.DTOs.Auth;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using JobEntry.Business.Extensions;
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
        public IActionResult Login(string ReturnUrl)
		{
			return View();
		}
		public async Task<IActionResult> ExternalResponse(string ReturnUrl = "/")
		{
			ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();
			if (loginInfo == null) return RedirectToAction("Login");

			Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);

			if(result.Succeeded) return Redirect(ReturnUrl);

			AppUser user = new AppUser();
			user.Email = loginInfo.Principal.FindFirstValue(ClaimTypes.Email);
			string externalUserId = loginInfo.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
			if (loginInfo.Principal.HasClaim(x => x.Type == ClaimTypes.Name))
			{
                string userName = loginInfo.Principal.FindFirst(ClaimTypes.Name).Value;
				userName = userName.Replace(' ', '_').ToLower() +'_'+ externalUserId.Substring(0, 5).ToString();
				user.FirstName = loginInfo.Principal.FindFirst(ClaimTypes.GivenName).Value;
				user.LastName = loginInfo.Principal.FindFirst(ClaimTypes.Surname).Value;
                user.UserName = userName;
            }
			IdentityResult createResult = await _userManager.CreateAsync(user);

			if(createResult.Succeeded)
			{
				IdentityResult loginResult = await _userManager.AddLoginAsync(user, loginInfo);
				if(loginResult.Succeeded)
				{
                    await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider,loginInfo.ProviderKey,true);
					return Redirect(ReturnUrl);
                }
				IdentityResultExtension.AddToModelState(loginResult, this.ModelState);

            }
            return RedirectToAction("Login");
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
		[HttpGet]
		public IActionResult FacebookLogin(string ReturnUrl)
		{
			string RedirectUrl = Url.Action("ExternalResponse", "Auth", new {ReturnUrl = ReturnUrl});
			AuthenticationProperties properties =  _signInManager.ConfigureExternalAuthenticationProperties("Facebook",redirectUrl: RedirectUrl);


			return new ChallengeResult("Facebook", properties);
		}
        [HttpGet]
        public IActionResult GoogleLogin(string ReturnUrl)
        {
            string RedirectUrl = Url.Action("ExternalResponse", "Auth", new { ReturnUrl = ReturnUrl });
            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl: RedirectUrl);


            return new ChallengeResult("Google", properties);
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
