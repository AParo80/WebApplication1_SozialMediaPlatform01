using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1_SozialMediaPlatform01.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Selbstbeschreibung = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistriertAm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nachricht",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post = table.Column<string>(type: "nvarchar(123)", maxLength: 123, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PostZeitpunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeepId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nachricht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nachricht_Peep_PeepId",
                        column: x => x.PeepId,
                        principalTable: "Peep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nachricht_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LikeBool = table.Column<bool>(type: "bit", nullable: false),
                    NachrichtId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Nachricht_NachrichtId",
                        column: x => x.NachrichtId,
                        principalTable: "Nachricht",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_NachrichtId",
                table: "Like",
                column: "NachrichtId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nachricht_PeepId",
                table: "Nachricht",
                column: "PeepId");

            migrationBuilder.CreateIndex(
                name: "IX_Nachricht_UserId",
                table: "Nachricht",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Nachricht");

            migrationBuilder.DropTable(
                name: "Peep");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
