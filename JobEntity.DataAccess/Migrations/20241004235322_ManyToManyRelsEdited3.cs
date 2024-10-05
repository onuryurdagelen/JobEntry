using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class ManyToManyRelsEdited3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrivingLicences_Criterions_CriterionId",
                table: "DrivingLicences");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationLevels_Criterions_CriterionId",
                table: "EducationLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Criterions_CriterionId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryStatuses_Criterions_CriterionId",
                table: "MilitaryStatuses");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryStatuses_CriterionId",
                table: "MilitaryStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_CriterionId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_EducationLevels_CriterionId",
                table: "EducationLevels");

            migrationBuilder.DropIndex(
                name: "IX_DrivingLicences_CriterionId",
                table: "DrivingLicences");

            migrationBuilder.DropColumn(
                name: "CriterionId",
                table: "MilitaryStatuses");

            migrationBuilder.DropColumn(
                name: "CriterionId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CriterionId",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "CriterionId",
                table: "DrivingLicences");

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

            migrationBuilder.AddColumn<Guid>(
                name: "CriterionId",
                table: "MilitaryStatuses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CriterionId",
                table: "Experiences",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CriterionId",
                table: "EducationLevels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CriterionId",
                table: "DrivingLicences",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryStatuses_CriterionId",
                table: "MilitaryStatuses",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CriterionId",
                table: "Experiences",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_CriterionId",
                table: "EducationLevels",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingLicences_CriterionId",
                table: "DrivingLicences",
                column: "CriterionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingLicences_Criterions_CriterionId",
                table: "DrivingLicences",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationLevels_Criterions_CriterionId",
                table: "EducationLevels",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Criterions_CriterionId",
                table: "Experiences",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryStatuses_Criterions_CriterionId",
                table: "MilitaryStatuses",
                column: "CriterionId",
                principalTable: "Criterions",
                principalColumn: "Id");
        }
    }
}
