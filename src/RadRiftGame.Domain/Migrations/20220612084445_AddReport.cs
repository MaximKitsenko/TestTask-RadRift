using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadRiftGame.Domain.Migrations
{
    public partial class AddReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamesResults",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    Player1Id = table.Column<Guid>(nullable: false),
                    HostId = table.Column<Guid>(nullable: false),
                    Player1Health = table.Column<decimal>(nullable: false),
                    HostHealth = table.Column<decimal>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesResults", x => x.GameId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesResults");
        }
    }
}
