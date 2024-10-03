using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class JobQualificationAndJobResponsibilityRelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Responsibilities_JobId",
                table: "Responsibilities");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_JobId",
                table: "Qualifications");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibilities_JobId",
                table: "Responsibilities",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_JobId",
                table: "Qualifications",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Responsibilities_JobId",
                table: "Responsibilities");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_JobId",
                table: "Qualifications");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibilities_JobId",
                table: "Responsibilities",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_JobId",
                table: "Qualifications",
                column: "JobId",
                unique: true);
        }
    }
}
