using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace dotnet_rpg.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    charId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    charName = table.Column<string>(type: "text", nullable: true),
                    charHitPoints = table.Column<int>(type: "integer", nullable: false),
                    charStrength = table.Column<int>(type: "integer", nullable: false),
                    charDefense = table.Column<int>(type: "integer", nullable: false),
                    charIntelligence = table.Column<int>(type: "integer", nullable: false),
                    charClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.charId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characters");
        }
    }
}
