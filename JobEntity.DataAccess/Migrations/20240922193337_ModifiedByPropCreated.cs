using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class ModifiedByPropCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ResponsibilityDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Responsibilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "QualificationDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ResponsibilityDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QualificationDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Companies");
        }
    }
}
