using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class CriterionManyToManyEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriterionDrivingLicenses");

            migrationBuilder.DropTable(
                name: "CriterionEducationLevels");

            migrationBuilder.DropTable(
                name: "CriterionExperiences");

            migrationBuilder.DropTable(
                name: "CriterionMilitaryStatuses");

            migrationBuilder.CreateTable(
                name: "CriterionDrivingLicense",
                columns: table => new
                {
                    CriterionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrivingLicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionDrivingLicense", x => new { x.CriterionId, x.DrivingLicenseId });
                    table.ForeignKey(
                        name: "FK_CriterionDrivingLicense_Criterions_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionDrivingLicense_DrivingLicences_DrivingLicenseId",
                        column: x => x.DrivingLicenseId,
                        principalTable: "DrivingLicences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionEducationLevel",
                columns: table => new
                {
                    CriterionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionEducationLevel", x => new { x.CriterionId, x.EducationLevelId });
                    table.ForeignKey(
                        name: "FK_CriterionEducationLevel_Criterions_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionEducationLevel_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionExperience",
                columns: table => new
                {
                    CriterionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionExperience", x => new { x.CriterionId, x.ExperienceId });
                    table.ForeignKey(
                        name: "FK_CriterionExperience_Criterions_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionExperience_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionMilitaryStatus",
                columns: table => new
                {
                    CriterionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilitaryStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionMilitaryStatus", x => new { x.CriterionId, x.MilitaryStatusId });
                    table.ForeignKey(
                        name: "FK_CriterionMilitaryStatus_Criterions_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionMilitaryStatus_MilitaryStatuses_MilitaryStatusId",
                        column: x => x.MilitaryStatusId,
                        principalTable: "MilitaryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriterionDrivingLicense_DrivingLicenseId",
                table: "CriterionDrivingLicense",
                column: "DrivingLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionEducationLevel_EducationLevelId",
                table: "CriterionEducationLevel",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionExperience_ExperienceId",
                table: "CriterionExperience",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionMilitaryStatus_MilitaryStatusId",
                table: "CriterionMilitaryStatus",
                column: "MilitaryStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriterionDrivingLicense");

            migrationBuilder.DropTable(
                name: "CriterionEducationLevel");

            migrationBuilder.DropTable(
                name: "CriterionExperience");

            migrationBuilder.DropTable(
                name: "CriterionMilitaryStatus");

            migrationBuilder.CreateTable(
                name: "CriterionDrivingLicenses",
                columns: table => new
                {
                    CriterionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrivingLicensesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionDrivingLicenses", x => new { x.CriterionsId, x.DrivingLicensesId });
                    table.ForeignKey(
                        name: "FK_CriterionDrivingLicenses_Criterions_CriterionsId",
                        column: x => x.CriterionsId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionDrivingLicenses_DrivingLicences_DrivingLicensesId",
                        column: x => x.DrivingLicensesId,
                        principalTable: "DrivingLicences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionEducationLevels",
                columns: table => new
                {
                    CriterionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionEducationLevels", x => new { x.CriterionsId, x.EducationLevelsId });
                    table.ForeignKey(
                        name: "FK_CriterionEducationLevels_Criterions_CriterionsId",
                        column: x => x.CriterionsId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionEducationLevels_EducationLevels_EducationLevelsId",
                        column: x => x.EducationLevelsId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionExperiences",
                columns: table => new
                {
                    CriterionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperiencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionExperiences", x => new { x.CriterionsId, x.ExperiencesId });
                    table.ForeignKey(
                        name: "FK_CriterionExperiences_Criterions_CriterionsId",
                        column: x => x.CriterionsId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionExperiences_Experiences_ExperiencesId",
                        column: x => x.ExperiencesId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionMilitaryStatuses",
                columns: table => new
                {
                    CriterionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilitaryStatusesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionMilitaryStatuses", x => new { x.CriterionsId, x.MilitaryStatusesId });
                    table.ForeignKey(
                        name: "FK_CriterionMilitaryStatuses_Criterions_CriterionsId",
                        column: x => x.CriterionsId,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriterionMilitaryStatuses_MilitaryStatuses_MilitaryStatusesId",
                        column: x => x.MilitaryStatusesId,
                        principalTable: "MilitaryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriterionDrivingLicenses_DrivingLicensesId",
                table: "CriterionDrivingLicenses",
                column: "DrivingLicensesId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionEducationLevels_EducationLevelsId",
                table: "CriterionEducationLevels",
                column: "EducationLevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionExperiences_ExperiencesId",
                table: "CriterionExperiences",
                column: "ExperiencesId");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionMilitaryStatuses_MilitaryStatusesId",
                table: "CriterionMilitaryStatuses",
                column: "MilitaryStatusesId");
        }
    }
}
