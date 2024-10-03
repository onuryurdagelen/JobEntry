using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class QualificationDetailsAndResponsibilityDetailsTblsRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationDetails_Qualifications_QualificationId",
                table: "QualificationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsibilityDetails_Responsibilities_ResponsibilityId",
                table: "ResponsibilityDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsibilityDetails",
                table: "ResponsibilityDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationDetails",
                table: "QualificationDetails");

            migrationBuilder.RenameTable(
                name: "ResponsibilityDetails",
                newName: "ResponsibilityDetail");

            migrationBuilder.RenameTable(
                name: "QualificationDetails",
                newName: "QualificationDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsibilityDetails_ResponsibilityId",
                table: "ResponsibilityDetail",
                newName: "IX_ResponsibilityDetail_ResponsibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationDetails_QualificationId",
                table: "QualificationDetail",
                newName: "IX_QualificationDetail_QualificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsibilityDetail",
                table: "ResponsibilityDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationDetail",
                table: "QualificationDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationDetail_Qualifications_QualificationId",
                table: "QualificationDetail",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsibilityDetail_Responsibilities_ResponsibilityId",
                table: "ResponsibilityDetail",
                column: "ResponsibilityId",
                principalTable: "Responsibilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualificationDetail_Qualifications_QualificationId",
                table: "QualificationDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsibilityDetail_Responsibilities_ResponsibilityId",
                table: "ResponsibilityDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsibilityDetail",
                table: "ResponsibilityDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationDetail",
                table: "QualificationDetail");

            migrationBuilder.RenameTable(
                name: "ResponsibilityDetail",
                newName: "ResponsibilityDetails");

            migrationBuilder.RenameTable(
                name: "QualificationDetail",
                newName: "QualificationDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsibilityDetail_ResponsibilityId",
                table: "ResponsibilityDetails",
                newName: "IX_ResponsibilityDetails_ResponsibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationDetail_QualificationId",
                table: "QualificationDetails",
                newName: "IX_QualificationDetails_QualificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsibilityDetails",
                table: "ResponsibilityDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationDetails",
                table: "QualificationDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationDetails_Qualifications_QualificationId",
                table: "QualificationDetails",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsibilityDetails_Responsibilities_ResponsibilityId",
                table: "ResponsibilityDetails",
                column: "ResponsibilityId",
                principalTable: "Responsibilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
