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
	public class EmployerMap : IEntityTypeConfiguration<Employer>
	{
		public void Configure(EntityTypeBuilder<Employer> builder)
		{
			
		}
		
	}
}
