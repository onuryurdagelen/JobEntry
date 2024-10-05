using JobEntry.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Mappings
{
    public class CriterionMap : IEntityTypeConfiguration<Criterion>
    {
        public void Configure(EntityTypeBuilder<Criterion> builder)
        {
            

       

        }
    }
    public class CriterionDrivingLicenseMap : IEntityTypeConfiguration<CriterionDrivingLicense>
    {
        public void Configure(EntityTypeBuilder<CriterionDrivingLicense> builder)
        {
            //Criterion-Driving License(many-to-many)
            builder.HasKey(cdl => new { cdl.CriterionId, cdl.DrivingLicenseId });
            // Configuring relationships
            builder
                .HasOne(sc => sc.Criterion)
                .WithMany(s => s.CriterionDrivingLicenses)
                .HasForeignKey(sc => sc.CriterionId);

            builder
              .HasOne(sc => sc.DrivingLicense)
              .WithMany(s => s.CriterionDrivingLicenses)
              .HasForeignKey(sc => sc.DrivingLicenseId);
        }
    }
    public class CriterionEducationLevelMap : IEntityTypeConfiguration<CriterionEducationLevel>
    {
        public void Configure(EntityTypeBuilder<CriterionEducationLevel> builder)
        {
            //Criterion-Education Level(many-to-many)
            builder.HasKey(cdl => new { cdl.CriterionId, cdl.EducationLevelId });
            // Configuring relationships
            builder
                .HasOne(sc => sc.Criterion)
                .WithMany(s => s.CriterionEducationLevels)
                .HasForeignKey(sc => sc.CriterionId);

            builder
              .HasOne(sc => sc.EducationLevel)
              .WithMany(s => s.CriterionEducationLevels)
              .HasForeignKey(sc => sc.EducationLevelId);
        }
    }
    public class CriterionExperienceMap : IEntityTypeConfiguration<CriterionExperience>
    {
        public void Configure(EntityTypeBuilder<CriterionExperience> builder)
        {
            //Criterion-Education Level(many-to-many)
            builder.HasKey(cdl => new { cdl.CriterionId, cdl.ExperienceId });
            // Configuring relationships
            builder
                .HasOne(sc => sc.Criterion)
                .WithMany(s => s.CriterionExperiences)
                .HasForeignKey(sc => sc.CriterionId);

            builder
              .HasOne(sc => sc.Experience)
              .WithMany(s => s.CriterionExperiences)
              .HasForeignKey(sc => sc.ExperienceId);
        }
    }
    public class CriterionMilitaryStatusMap : IEntityTypeConfiguration<CriterionMilitaryStatus>
    {
        public void Configure(EntityTypeBuilder<CriterionMilitaryStatus> builder)
        {
            //Criterion-Education Level(many-to-many)
            builder.HasKey(cdl => new { cdl.CriterionId, cdl.MilitaryStatusId });
            // Configuring relationships
            builder
                .HasOne(sc => sc.Criterion)
                .WithMany(s => s.CriterionMilitaryStatuses)
                .HasForeignKey(sc => sc.CriterionId);

            builder
              .HasOne(sc => sc.MilitaryStatus)
              .WithMany(s => s.CriterionMilitaryStatuses)
              .HasForeignKey(sc => sc.MilitaryStatusId);
        }
    }
}
