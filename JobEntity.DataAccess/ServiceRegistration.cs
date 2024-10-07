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

				switch (configuration.GetSection("DbProvider").Value)
				{
                    case "NpgSql":
						options.UseNpgsql(configuration.GetConnectionString("Npgsql"), config =>
						{
							config.MigrationsAssembly("PostgreSql");
						});
						AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                        break;
                    case "SqlServer":
                        options.UseSqlServer(configuration.GetConnectionString("SqlServer"), config =>
                        {
                            config.MigrationsAssembly("SqlServer");
                        });
                        break;
                        
                    default:
                        options.UseSqlServer(configuration.GetConnectionString("SqlServer"), config =>
                        {
                            config.MigrationsAssembly("SqlServer");
                        });
                        break;
                }


				
				options.EnableSensitiveDataLogging();
			});
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<ContextSeedData>();

			




			return services;
		}
	}
}
