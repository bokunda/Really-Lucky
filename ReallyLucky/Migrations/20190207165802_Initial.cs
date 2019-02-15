using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReallyLuckyBackend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImgSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTimeStarted = table.Column<DateTime>(nullable: false),
                    DateTimeEnded = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RoundId = table.Column<int>(nullable: false),
                    RoundId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Rounds_RoundId1",
                        column: x => x.RoundId1,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuckySixBalls",
                columns: table => new
                {
                    LuckySixBallsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    RoundId = table.Column<int>(nullable: false),
                    RoundId1 = table.Column<long>(nullable: true),
                    TicketId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuckySixBalls", x => x.LuckySixBallsId);
                    table.ForeignKey(
                        name: "FK_LuckySixBalls_Rounds_RoundId1",
                        column: x => x.RoundId1,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LuckySixBalls_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LuckySixBalls_RoundId1",
                table: "LuckySixBalls",
                column: "RoundId1");

            migrationBuilder.CreateIndex(
                name: "IX_LuckySixBalls_TicketId",
                table: "LuckySixBalls",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RoundId1",
                table: "Tickets",
                column: "RoundId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LuckySixBalls");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
