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
    public class WishMap : IEntityTypeConfiguration<Wish>
    {
        public void Configure(EntityTypeBuilder<Wish> builder)
        {
            builder
                .HasMany(w => w.Products)
                .WithMany(p => p.Wishes)
                .UsingEntity(j => j.ToTable("WishProducts"));
        }
    }
}
