using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntity.DataAccess.Migrations
{
    public partial class JobNameToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "Name");
        }
    }
}
