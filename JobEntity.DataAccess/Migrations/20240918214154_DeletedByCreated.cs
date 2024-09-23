using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class DeletedByCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ResponsibilityDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ResponsibilityDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Responsibilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Responsibilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Qualifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "QualificationDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "QualificationDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ResponsibilityDetails");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ResponsibilityDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "QualificationDetails");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "QualificationDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Companies");
        }
    }
}
