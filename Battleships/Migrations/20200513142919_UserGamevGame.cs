using Microsoft.EntityFrameworkCore.Migrations;

namespace Battleships.Migrations
{
    public partial class UserGamevGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameSize",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "GameState",
                table: "UserGames");

            migrationBuilder.CreateIndex(
                name: "IX_NavyBattlePieces_PosX_PosY",
                table: "NavyBattlePieces",
                columns: new[] { "PosX", "PosY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NavyBattlePieces_PosX_PosY",
                table: "NavyBattlePieces");

            migrationBuilder.AddColumn<int>(
                name: "GameSize",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameState",
                table: "UserGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
