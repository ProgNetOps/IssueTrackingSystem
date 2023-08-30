using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedBaseStationToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BTSName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Coordinates = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseStations_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NetworkSwitch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwitchName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SwitchIP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BTSId = table.Column<int>(type: "int", nullable: false),
                    ConfigBackup = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DateOfLastBackup = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkSwitch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkSwitch_BaseStations_BTSId",
                        column: x => x.BTSId,
                        principalTable: "BaseStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseStations_StateId",
                table: "BaseStations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkSwitch_BTSId",
                table: "NetworkSwitch",
                column: "BTSId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkSwitch");

            migrationBuilder.DropTable(
                name: "BaseStations");
        }
    }
}
