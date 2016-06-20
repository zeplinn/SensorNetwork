using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace SensorNetwork.Models.Migrations
{
    public partial class SensorNetworkDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Host = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true),
                    Password = table.Column<string>(type: "varchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    IP = table.Column<long>(type: "bigint", nullable: false),
                    NetworkId = table.Column<int>(nullable: true),
                    Tag = table.Column<string>(type: "varchar(25)", nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Time = table.Column<DateTime>(nullable: false),
                    SensorId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => new { x.Time, x.SensorId });
                    table.ForeignKey(
                        name: "FK_Reading_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Readings");
            migrationBuilder.DropTable("Sensors");
            migrationBuilder.DropTable("Network");
        }
    }
}
