using JobEntity.DataAccess.Context;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

namespace JobEntry.Web
{
    public static class ServiceRegistration
    {
        public static IServiceCollection LoadMvcServices(this IServiceCollection services,IConfiguration configuration)
        {

            //Identity Configuration
            services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				//options.SignIn.RequireConfirmedPhoneNumber = false;
				//options.SignIn.RequireConfirmedAccount = false;
				//options.SignIn.RequireConfirmedEmail = false;
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 5;
			}).AddRoleManager<RoleManager<AppRole>>()
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(config =>
			{
				config.LoginPath = new PathString("/Admin/Auth/Login");
				config.LogoutPath = new PathString("/Admin/Auth/Logout");
				config.Cookie = new CookieBuilder
				{
					Name = "JobEntryAuthCookie",
					HttpOnly = true,
					SameSite = SameSiteMode.Strict,
					SecurePolicy = CookieSecurePolicy.SameAsRequest, //hem http hem https olarak çalışır.Canlıya alınca Always seçilmeli
				};
				config.SlidingExpiration = true;
				config.ExpireTimeSpan = TimeSpan.FromDays(7); //7 gün boyunca açık oturum açık kalacak.
				config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
			});
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(7);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
    }
}
