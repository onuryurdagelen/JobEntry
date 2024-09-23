using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class ModifiedDatePropCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ResponsibilityDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Responsibilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Qualifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "QualificationDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ResponsibilityDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "QualificationDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Companies");
        }
    }
}
