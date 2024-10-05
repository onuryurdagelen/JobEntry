using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class CriterionManyToManyNamedEditer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriterionDrivingLicense_Criterions_CriterionId",
                table: "CriterionDrivingLicense");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionDrivingLicense_DrivingLicences_DrivingLicenseId",
                table: "CriterionDrivingLicense");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionEducationLevel_Criterions_CriterionId",
                table: "CriterionEducationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionEducationLevel_EducationLevels_EducationLevelId",
                table: "CriterionEducationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionExperience_Criterions_CriterionId",
                table: "CriterionExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionExperience_Experiences_ExperienceId",
                table: "CriterionExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionMilitaryStatus_Criterions_CriterionId",
                table: "CriterionMilitaryStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionMilitaryStatus_MilitaryStatuses_MilitaryStatusId",
                table: "CriterionMilitaryStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionMilitaryStatus",
                table: "CriterionMilitaryStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionExperience",
                table: "CriterionExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionEducationLevel",
                table: "CriterionEducationLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionDrivingLicense",
                table: "CriterionDrivingLicense");

            migrationBuilder.RenameTable(
                name: "CriterionMilitaryStatus",
                newName: "CriterionMilitaryStatuses");

            migrationBuilder.RenameTable(
                name: "CriterionExperience",
                newName: "CriterionExperiences");

            migrationBuilder.RenameTable(
                name: "CriterionEducationLevel",
                newName: "CriterionEducationLevels");

            migrationBuilder.RenameTable(
                name: "CriterionDrivingLicense",
                newName: "CriterionDrivingLicenses");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionMilitaryStatus_MilitaryStatusId",
                table: "CriterionMilitaryStatuses",
                newName: "IX_CriterionMilitaryStatuses_MilitaryStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionExperience_ExperienceId",
                table: "CriterionExperiences",
                newName: "IX_CriterionExperiences_ExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionEducationLevel_EducationLevelId",
                table: "CriterionEducationLevels",
                newName: "IX_CriterionEducationLevels_EducationLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionDrivingLicense_DrivingLicenseId",
                table: "CriterionDrivingLicenses",
                newName: "IX_CriterionDrivingLicenses_DrivingLicenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionMilitaryStatuses",
                table: "CriterionMilitaryStatuses",
                columns: new[] { "CriterionId", "MilitaryStatusId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionExperiences",
                table: "CriterionExperiences",
                columns: new[] { "CriterionId", "ExperienceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionEducationLevels",
                table: "CriterionEducationLevels",
                columns: new[] { "CriterionId", "EducationLevelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionDrivingLicenses",
                table: "CriterionDrivingLicenses",
                columns: new[] { "CriterionId", "DrivingLicenseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionDrivingLicenses_Criterions_CriterionId",
                table: "CriterionDrivingLicenses",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionDrivingLicenses_DrivingLicences_DrivingLicenseId",
                table: "CriterionDrivingLicenses",
                column: "DrivingLicenseId",
                principalTable: "DrivingLicences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionEducationLevels_Criterions_CriterionId",
                table: "CriterionEducationLevels",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionEducationLevels_EducationLevels_EducationLevelId",
                table: "CriterionEducationLevels",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionExperiences_Criterions_CriterionId",
                table: "CriterionExperiences",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionExperiences_Experiences_ExperienceId",
                table: "CriterionExperiences",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionMilitaryStatuses_Criterions_CriterionId",
                table: "CriterionMilitaryStatuses",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionMilitaryStatuses_MilitaryStatuses_MilitaryStatusId",
                table: "CriterionMilitaryStatuses",
                column: "MilitaryStatusId",
                principalTable: "MilitaryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriterionDrivingLicenses_Criterions_CriterionId",
                table: "CriterionDrivingLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionDrivingLicenses_DrivingLicences_DrivingLicenseId",
                table: "CriterionDrivingLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionEducationLevels_Criterions_CriterionId",
                table: "CriterionEducationLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionEducationLevels_EducationLevels_EducationLevelId",
                table: "CriterionEducationLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionExperiences_Criterions_CriterionId",
                table: "CriterionExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionExperiences_Experiences_ExperienceId",
                table: "CriterionExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionMilitaryStatuses_Criterions_CriterionId",
                table: "CriterionMilitaryStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_CriterionMilitaryStatuses_MilitaryStatuses_MilitaryStatusId",
                table: "CriterionMilitaryStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionMilitaryStatuses",
                table: "CriterionMilitaryStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionExperiences",
                table: "CriterionExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionEducationLevels",
                table: "CriterionEducationLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriterionDrivingLicenses",
                table: "CriterionDrivingLicenses");

            migrationBuilder.RenameTable(
                name: "CriterionMilitaryStatuses",
                newName: "CriterionMilitaryStatus");

            migrationBuilder.RenameTable(
                name: "CriterionExperiences",
                newName: "CriterionExperience");

            migrationBuilder.RenameTable(
                name: "CriterionEducationLevels",
                newName: "CriterionEducationLevel");

            migrationBuilder.RenameTable(
                name: "CriterionDrivingLicenses",
                newName: "CriterionDrivingLicense");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionMilitaryStatuses_MilitaryStatusId",
                table: "CriterionMilitaryStatus",
                newName: "IX_CriterionMilitaryStatus_MilitaryStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionExperiences_ExperienceId",
                table: "CriterionExperience",
                newName: "IX_CriterionExperience_ExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionEducationLevels_EducationLevelId",
                table: "CriterionEducationLevel",
                newName: "IX_CriterionEducationLevel_EducationLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CriterionDrivingLicenses_DrivingLicenseId",
                table: "CriterionDrivingLicense",
                newName: "IX_CriterionDrivingLicense_DrivingLicenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionMilitaryStatus",
                table: "CriterionMilitaryStatus",
                columns: new[] { "CriterionId", "MilitaryStatusId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionExperience",
                table: "CriterionExperience",
                columns: new[] { "CriterionId", "ExperienceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionEducationLevel",
                table: "CriterionEducationLevel",
                columns: new[] { "CriterionId", "EducationLevelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriterionDrivingLicense",
                table: "CriterionDrivingLicense",
                columns: new[] { "CriterionId", "DrivingLicenseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionDrivingLicense_Criterions_CriterionId",
                table: "CriterionDrivingLicense",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionDrivingLicense_DrivingLicences_DrivingLicenseId",
                table: "CriterionDrivingLicense",
                column: "DrivingLicenseId",
                principalTable: "DrivingLicences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionEducationLevel_Criterions_CriterionId",
                table: "CriterionEducationLevel",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionEducationLevel_EducationLevels_EducationLevelId",
                table: "CriterionEducationLevel",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionExperience_Criterions_CriterionId",
                table: "CriterionExperience",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionExperience_Experiences_ExperienceId",
                table: "CriterionExperience",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionMilitaryStatus_Criterions_CriterionId",
                table: "CriterionMilitaryStatus",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriterionMilitaryStatus_MilitaryStatuses_MilitaryStatusId",
                table: "CriterionMilitaryStatus",
                column: "MilitaryStatusId",
                principalTable: "MilitaryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
