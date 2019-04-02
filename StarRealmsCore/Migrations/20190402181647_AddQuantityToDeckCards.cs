using Microsoft.EntityFrameworkCore.Migrations;

namespace StarRealmsCore.Migrations
{
    public partial class AddQuantityToDeckCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "DeckCards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "DeckCards");
        }
    }
}
