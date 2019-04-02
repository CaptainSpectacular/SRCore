using Microsoft.EntityFrameworkCore.Migrations;

namespace StarRealmsCore.Migrations
{
    public partial class AddGameToDeck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Decks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_GameId",
                table: "Decks",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Games_GameId",
                table: "Decks",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Games_GameId",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_GameId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Decks");
        }
    }
}
