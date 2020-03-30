using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(maxLength: 25, nullable: false),
                    Destination = table.Column<string>(maxLength: 100, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Author", "City", "Country", "Description", "Destination", "Rating" },
                values: new object[,]
                {
                    { 1, "Michelle", "Paris", "France", "too crowded, some cool art", "Louvre", 3 },
                    { 2, "Joe", "Cartago", "Costa Rica", "it's a volcano", "Irazu volcano national park", 4 },
                    { 3, "Cletus", "Cedar Creek", "Canada", "real nice", "The sticks", 5 },
                    { 4, "James", "Sydney", "Australia", "It was aight", "Da Club", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
