using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class JobTblEducationLevelIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_EducationLevels_EducationLevelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EducationLevelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EducationLevelId",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EducationLevelId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EducationLevelId",
                table: "Jobs",
                column: "EducationLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_EducationLevels_EducationLevelId",
                table: "Jobs",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id");
        }
    }
}
