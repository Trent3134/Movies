using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRater.Data.Migrations
{
    public partial class removedshowsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ShowEntity_ShowEntityId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "ShowEntity");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ShowEntityId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ShowEntityId",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowEntityId",
                table: "Ratings",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ShowEntityId",
                table: "Ratings",
                column: "ShowEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ShowEntity_ShowEntityId",
                table: "Ratings",
                column: "ShowEntityId",
                principalTable: "ShowEntity",
                principalColumn: "Id");
        }
    }
}
