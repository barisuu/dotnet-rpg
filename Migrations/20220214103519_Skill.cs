using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace dotnet_rpg.Migrations
{
    public partial class Skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Damage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "characterskills",
                columns: table => new
                {
                    CharacterFK = table.Column<int>(type: "integer", nullable: false),
                    SkillFK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characterskills", x => new { x.CharacterFK, x.SkillFK });
                    table.ForeignKey(
                        name: "FK_characterskills_characters_CharacterFK",
                        column: x => x.CharacterFK,
                        principalTable: "characters",
                        principalColumn: "charId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characterskills_skills_SkillFK",
                        column: x => x.SkillFK,
                        principalTable: "skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_characterskills_SkillFK",
                table: "characterskills",
                column: "SkillFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characterskills");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
