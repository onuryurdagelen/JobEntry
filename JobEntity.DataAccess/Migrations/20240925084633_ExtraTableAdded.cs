using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class ExtraTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Jobs",
                newName: "Province");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CriterionId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EducationLevelId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExperienced",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "JobLanguageId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PositionLevelId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SectorId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkPreferenceId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkTypeId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrivingLicences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criterions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MilitaryStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrivingLicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criterions_DrivingLicences_DrivingLicenseId",
                        column: x => x.DrivingLicenseId,
                        principalTable: "DrivingLicences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criterions_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criterions_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Criterions_MilitaryStatus_MilitaryStatusId",
                        column: x => x.MilitaryStatusId,
                        principalTable: "MilitaryStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CriterionId",
                table: "Jobs",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DepartmentId",
                table: "Jobs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EducationLevelId",
                table: "Jobs",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobLanguageId",
                table: "Jobs",
                column: "JobLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PositionId",
                table: "Jobs",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PositionLevelId",
                table: "Jobs",
                column: "PositionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SectorId",
                table: "Jobs",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkPreferenceId",
                table: "Jobs",
                column: "WorkPreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkTypeId",
                table: "Jobs",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterions_DrivingLicenseId",
                table: "Criterions",
                column: "DrivingLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterions_EducationLevelId",
                table: "Criterions",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterions_ExperienceId",
                table: "Criterions",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterions_MilitaryStatusId",
                table: "Criterions",
                column: "MilitaryStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Criterions_CriterionId",
                table: "Jobs",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Departments_DepartmentId",
                table: "Jobs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_EducationLevels_EducationLevelId",
                table: "Jobs",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLanguages_JobLanguageId",
                table: "Jobs",
                column: "JobLanguageId",
                principalTable: "JobLanguages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_PositionLevels_PositionLevelId",
                table: "Jobs",
                column: "PositionLevelId",
                principalTable: "PositionLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Positions_PositionId",
                table: "Jobs",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Sectors_SectorId",
                table: "Jobs",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_WorkPreferences_WorkPreferenceId",
                table: "Jobs",
                column: "WorkPreferenceId",
                principalTable: "WorkPreferences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_WorkTypes_WorkTypeId",
                table: "Jobs",
                column: "WorkTypeId",
                principalTable: "WorkTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Criterions_CriterionId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Departments_DepartmentId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_EducationLevels_EducationLevelId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLanguages_JobLanguageId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_PositionLevels_PositionLevelId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Positions_PositionId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Sectors_SectorId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_WorkPreferences_WorkPreferenceId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_WorkTypes_WorkTypeId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Criterions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "JobLanguages");

            migrationBuilder.DropTable(
                name: "PositionLevels");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "WorkPreferences");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "DrivingLicences");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "MilitaryStatus");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CriterionId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_DepartmentId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EducationLevelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobLanguageId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_PositionId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_PositionLevelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_SectorId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_WorkPreferenceId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_WorkTypeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CriterionId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EducationLevelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsExperienced",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobLanguageId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PositionLevelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkPreferenceId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Jobs",
                newName: "Location");
        }
    }
}
