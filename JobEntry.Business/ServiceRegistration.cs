using FluentValidation;
using FluentValidation.AspNetCore;
using JobEntry.Business.Exceptions;
using JobEntry.Business.FluentValidations;
using JobEntry.Business.Helpers.Images;
using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Services.Concretes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace JobEntry.Business
{
	public static class ServiceRegistration
	{
		public static IServiceCollection LoadBusinessServices(this IServiceCollection services)
		{

			services.AddScoped<ICompanyService, CompanyService>();
			services.AddScoped<IJobService, JobService>();
			services.AddScoped<IImageHelper,ImageHelper>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddTransient<ExceptionMiddleware>();

			services.AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblyContaining<JobValidator>();
				options.DisableDataAnnotationsValidation = true;
				options.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("en-US");

			});

			return services;
		}
		public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
