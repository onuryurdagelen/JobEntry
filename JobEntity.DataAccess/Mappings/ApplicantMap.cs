using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Mappings
{
	public class ApplicantMap : IEntityTypeConfiguration<Applicant>
	{
		public void Configure(EntityTypeBuilder<Applicant> builder)
		{
	
			//ApplicantUser-Job(many-to-many)
			builder
				.HasMany(x => x.Jobs)
				.WithMany(x => x.Applicants)
				.UsingEntity<Dictionary<object, object>>(
				"JobApplicants",
				x => x.HasOne<Job>().WithMany().HasForeignKey("Job_Id").HasConstraintName("FK_Job_Id"),
				x => x.HasOne<Applicant>().WithMany().HasForeignKey("Applicant_Id").HasConstraintName("FK_Applicant_Id")
				);

		}
	}
}
