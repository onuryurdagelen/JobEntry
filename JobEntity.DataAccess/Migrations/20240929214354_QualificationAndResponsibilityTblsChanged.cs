using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class QualificationAndResponsibilityTblsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Responsibilities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Qualifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Responsibilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Responsibilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Responsibilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Responsibilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Responsibilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Qualifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Qualifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Qualifications",
                type: "datetime2",
                nullable: true);
        }
    }
}
