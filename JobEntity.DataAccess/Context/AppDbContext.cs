using JobEntity.DataAccess.Mappings;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Context
{
	public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
	{
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employer> Employers { get; set; }

        public DbSet<QualificationDetail> QualificationDetails { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<ResponsibilityDetail> ResponsibilityDetails { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorkPreference> WorkPreferences { get; set; }
        public DbSet<DrivingLicense> DrivingLicences { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatus { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Criterion> Criterions { get; set; }
        public DbSet<JobLanguage> JobLanguages { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PositionLevel> PositionLevels { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }



        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
			//modelBuilder.ApplyConfiguration(new CompanyMap());
			//modelBuilder.ApplyConfiguration(new ImageMap());
			//modelBuilder.ApplyConfiguration(new JobMap());

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
		

	}
}
