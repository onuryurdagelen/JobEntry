using JobEntry.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Mappings
{
	public class ResponsibilityDetailMap : IEntityTypeConfiguration<ResponsibilityDetail>
	{
		public void Configure(EntityTypeBuilder<ResponsibilityDetail> builder)
		{
			builder.Property(b => b.CreatedDate).ValueGeneratedOnAdd();
		}
	}
}
