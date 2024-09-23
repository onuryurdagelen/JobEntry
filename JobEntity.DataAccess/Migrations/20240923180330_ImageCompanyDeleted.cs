using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class ImageCompanyDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CompanyId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ImageId",
                table: "Companies",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Images_ImageId",
                table: "Companies",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Images_ImageId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ImageId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Companies");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CompanyId",
                table: "Images",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
