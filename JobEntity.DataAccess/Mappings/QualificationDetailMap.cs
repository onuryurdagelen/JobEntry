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
	public class QualificationDetailMap : IEntityTypeConfiguration<QualificationDetail>
	{
		public void Configure(EntityTypeBuilder<QualificationDetail> builder)
		{
			builder.Property(b => b.CreatedDate).ValueGeneratedOnAdd();
		}
	}
}
