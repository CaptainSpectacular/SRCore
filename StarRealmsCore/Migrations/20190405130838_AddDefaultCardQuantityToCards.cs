using Microsoft.EntityFrameworkCore.Migrations;

namespace StarRealmsCore.Migrations
{
    public partial class AddDefaultCardQuantityToCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultQuantity",
                table: "Cards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultQuantity",
                table: "Cards");
        }
    }
}
