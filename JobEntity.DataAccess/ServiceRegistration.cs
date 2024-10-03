using JobEntity.DataAccess.Context;
using JobEntity.DataAccess.Repositories.Abstracts;
using JobEntity.DataAccess.Repositories.Concretes;
using JobEntity.DataAccess.Seed;
using JobEntity.DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess
{
	public static class ServiceRegistration
	{
		public static IServiceCollection LoadDataAccessServices(this IServiceCollection services, IConfiguration configuration) 
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("SqlServer"),option =>
				{
					option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
				});
				options.EnableSensitiveDataLogging();
			});
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<ContextSeedData>();

			




			return services;
		}
	}
}
