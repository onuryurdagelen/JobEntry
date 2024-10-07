using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServer.Migrations
{
    public partial class ReviewsDescriptionPropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reviews");
        }
    }
}
