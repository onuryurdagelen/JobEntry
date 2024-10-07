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
    public class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasMany(r => r.SubReviews)
                .WithOne(r => r.ParentReview)
                .HasForeignKey(r => r.ParentReviewId);
        }
    }
}
