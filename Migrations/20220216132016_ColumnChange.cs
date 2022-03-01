using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_rpg.Migrations
{
    public partial class ColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "charStrength",
                table: "characters",
                newName: "Strength");

            migrationBuilder.RenameColumn(
                name: "charName",
                table: "characters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "charIntelligence",
                table: "characters",
                newName: "Intelligence");

            migrationBuilder.RenameColumn(
                name: "charHitPoints",
                table: "characters",
                newName: "Hitpoints");

            migrationBuilder.RenameColumn(
                name: "charDefense",
                table: "characters",
                newName: "Defense");

            migrationBuilder.RenameColumn(
                name: "charClass",
                table: "characters",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "charId",
                table: "characters",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "characters",
                newName: "charStrength");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "characters",
                newName: "charName");

            migrationBuilder.RenameColumn(
                name: "Intelligence",
                table: "characters",
                newName: "charIntelligence");

            migrationBuilder.RenameColumn(
                name: "Hitpoints",
                table: "characters",
                newName: "charHitPoints");

            migrationBuilder.RenameColumn(
                name: "Defense",
                table: "characters",
                newName: "charDefense");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "characters",
                newName: "charClass");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "characters",
                newName: "charId");
        }
    }
}
