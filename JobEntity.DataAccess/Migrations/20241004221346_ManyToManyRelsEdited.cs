using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class ManyToManyRelsEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriterionDrivingLicenseManyToMany");

            migrationBuilder.DropTable(
                name: "CriterionEducationLevelManyToMany");

            migrationBuilder.DropTable(
                name: "CriterionExperienceManyToMany");

            migrationBuilder.DropTable(
                name: "CriterionMilitaryStatusManyToMany");
  

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CriterionDrivingLicenseManyToMany",
                columns: table => new
                {
                    CriterionDrivingLicense_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrivingLicense_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionDrivingLicenseManyToMany", x => new { x.CriterionDrivingLicense_Id, x.DrivingLicense_Id });
                    table.ForeignKey(
                        name: "FK_CriterionDrivingLicense_Id",
                        column: x => x.CriterionDrivingLicense_Id,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrivingLicense_Id",
                        column: x => x.DrivingLicense_Id,
                        principalTable: "DrivingLicences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionEducationLevelManyToMany",
                columns: table => new
                {
                    CriterionEducationLevel_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevel_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionEducationLevelManyToMany", x => new { x.CriterionEducationLevel_Id, x.EducationLevel_Id });
                    table.ForeignKey(
                        name: "FK_CriterionEducationLevel_Id",
                        column: x => x.CriterionEducationLevel_Id,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationLevel_Id",
                        column: x => x.EducationLevel_Id,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionExperienceManyToMany",
                columns: table => new
                {
                    CriterionExperience_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Experience_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionExperienceManyToMany", x => new { x.CriterionExperience_Id, x.Experience_Id });
                    table.ForeignKey(
                        name: "FK_CriterionExperience_Id",
                        column: x => x.CriterionExperience_Id,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experience_Id",
                        column: x => x.Experience_Id,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriterionMilitaryStatusManyToMany",
                columns: table => new
                {
                    CriterionMilitaryStatus_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilitaryStatus_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriterionMilitaryStatusManyToMany", x => new { x.CriterionMilitaryStatus_Id, x.MilitaryStatus_Id });
                    table.ForeignKey(
                        name: "FK_CriterionMilitaryStatus_Id",
                        column: x => x.CriterionMilitaryStatus_Id,
                        principalTable: "Criterions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryStatus_Id",
                        column: x => x.MilitaryStatus_Id,
                        principalTable: "MilitaryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            

           

            migrationBuilder.CreateIndex(
                name: "IX_CriterionDrivingLicenseManyToMany_DrivingLicense_Id",
                table: "CriterionDrivingLicenseManyToMany",
                column: "DrivingLicense_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionEducationLevelManyToMany_EducationLevel_Id",
                table: "CriterionEducationLevelManyToMany",
                column: "EducationLevel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionExperienceManyToMany_Experience_Id",
                table: "CriterionExperienceManyToMany",
                column: "Experience_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CriterionMilitaryStatusManyToMany_MilitaryStatus_Id",
                table: "CriterionMilitaryStatusManyToMany",
                column: "MilitaryStatus_Id");

        
        }
    }
}
