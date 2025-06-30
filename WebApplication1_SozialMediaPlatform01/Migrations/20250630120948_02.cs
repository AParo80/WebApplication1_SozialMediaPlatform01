using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1_SozialMediaPlatform01.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeepWort = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NachrichtPeep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NachrichtId = table.Column<int>(type: "int", nullable: true),
                    PeepId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NachrichtPeep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NachrichtPeep_Nachricht_NachrichtId",
                        column: x => x.NachrichtId,
                        principalTable: "Nachricht",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NachrichtPeep_Peep_PeepId",
                        column: x => x.PeepId,
                        principalTable: "Peep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NachrichtPeep_NachrichtId",
                table: "NachrichtPeep",
                column: "NachrichtId");

            migrationBuilder.CreateIndex(
                name: "IX_NachrichtPeep_PeepId",
                table: "NachrichtPeep",
                column: "PeepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NachrichtPeep");

            migrationBuilder.DropTable(
                name: "Peep");
        }
    }
}
