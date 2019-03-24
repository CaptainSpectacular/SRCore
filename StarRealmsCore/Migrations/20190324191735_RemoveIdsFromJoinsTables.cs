using Microsoft.EntityFrameworkCore.Migrations;

namespace StarRealmsCore.Migrations
{
    public partial class RemoveIdsFromJoinsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TradeCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FieldCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeckCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CardFactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CardEffects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TradeCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FieldCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeckCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CardFactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CardEffects",
                nullable: false,
                defaultValue: 0);
        }
    }
}
