using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRater.Data.Migrations
{
    public partial class AddedshowsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShowEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieEntityId = table.Column<int>(type: "int", nullable: true),
                    ShowEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieEntityId",
                        column: x => x.MovieEntityId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_ShowEntity_ShowEntityId",
                        column: x => x.ShowEntityId,
                        principalTable: "ShowEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieEntityId",
                table: "Ratings",
                column: "MovieEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ShowEntityId",
                table: "Ratings",
                column: "ShowEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ShowEntity");
        }
    }
}
