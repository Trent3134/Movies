using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRater.Data.Migrations
{
    public partial class I2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowEntityId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreType = table.Column<int>(type: "int", nullable: false),
                    ParentalAdvisory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ShowEntityId",
                table: "Ratings",
                column: "ShowEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Shows_ShowEntityId",
                table: "Ratings",
                column: "ShowEntityId",
                principalTable: "Shows",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Shows_ShowEntityId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ShowEntityId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ShowEntityId",
                table: "Ratings");
        }
    }
}
