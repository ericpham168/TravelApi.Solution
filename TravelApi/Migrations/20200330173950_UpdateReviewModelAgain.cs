using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class UpdateReviewModelAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Reviews",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Reviews");
        }
    }
}
