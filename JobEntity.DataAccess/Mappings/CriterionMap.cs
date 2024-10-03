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
            //Criterion-Driving License(many-to-many)
            builder
                .HasMany(x => x.DrivingLicenses)
                .WithMany(x => x.Criterions)
                .UsingEntity<Dictionary<object, object>>(
                "CriterionDrivingLicenseManyToMany",
                x => x.HasOne<DrivingLicense>().WithMany().HasForeignKey("DrivingLicense_Id").HasConstraintName("FK_DrivingLicense_Id"),
                x => x.HasOne<Criterion>().WithMany().HasForeignKey("CriterionDrivingLicense_Id").HasConstraintName("FK_CriterionDrivingLicense_Id")
                );

            //Criterion-Military Status(many-to-many)
            builder
                .HasMany(x => x.MilitaryStatuses)
                .WithMany(x => x.Criterions)
                .UsingEntity<Dictionary<object, object>>(
                "CriterionMilitaryStatusManyToMany",
                x => x.HasOne<MilitaryStatus>().WithMany().HasForeignKey("MilitaryStatus_Id").HasConstraintName("FK_MilitaryStatus_Id"),
                x => x.HasOne<Criterion>().WithMany().HasForeignKey("CriterionMilitaryStatus_Id").HasConstraintName("FK_CriterionMilitaryStatus_Id")
                );

            //Criterion-Education Level(many-to-many)
            builder
                .HasMany(x => x.EducationLevels)
                .WithMany(x => x.Criterions)
                .UsingEntity<Dictionary<object, object>>(
                "CriterionEducationLevelManyToMany",
                x => x.HasOne<EducationLevel>().WithMany().HasForeignKey("EducationLevel_Id").HasConstraintName("FK_EducationLevel_Id"),
                x => x.HasOne<Criterion>().WithMany().HasForeignKey("CriterionEducationLevel_Id").HasConstraintName("FK_CriterionEducationLevel_Id")
                );

            //Criterion-Experience(many-to-many)
            builder
                .HasMany(x => x.Experiences)
                .WithMany(x => x.Criterions)
                .UsingEntity<Dictionary<object, object>>(
                "CriterionExperienceManyToMany",
                x => x.HasOne<Experience>().WithMany().HasForeignKey("Experience_Id").HasConstraintName("FK_Experience_Id"),
                x => x.HasOne<Criterion>().WithMany().HasForeignKey("CriterionExperience_Id").HasConstraintName("FK_CriterionExperience_Id")
                );
        }
    }
}
