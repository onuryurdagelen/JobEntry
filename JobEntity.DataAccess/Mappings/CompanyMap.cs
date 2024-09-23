using JobEntry.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Mappings
{
	public class CompanyMap : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{

			builder.Property(b => b.CreatedDate).ValueGeneratedOnAdd();

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Description)
				.IsUnicode(false)
				.HasMaxLength(500);

			
		}
	}
}
