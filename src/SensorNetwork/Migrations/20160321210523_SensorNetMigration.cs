using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace SensorNetwork.Migrations
{
    public partial class SensorNetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    NetworkId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    NetworkName = table.Column<string>(type: "varchar(45)", nullable: false),
                    Host = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => new { x.NetworkId, x.NetworkName });
                });
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    IP = table.Column<long>(type: "bigint", nullable: false),
                    NetworkNetworkId = table.Column<int>(nullable: true),
                    NetworkNetworkName = table.Column<string>(nullable: true),
                    SensorType = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(type: "varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => new { x.SensorId, x.IP });
                    table.ForeignKey(
                        name: "FK_Sensor_Network_NetworkNetworkId_NetworkNetworkName",
                        columns: x => new { x.NetworkNetworkId, x.NetworkNetworkName },
                        principalTable: "Network",
                        principalColumns: new[] { "NetworkId", "NetworkName" },
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    ReadingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    SensorIP = table.Column<long>(nullable: true),
                    SensorSensorId = table.Column<int>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ReadingID);
                    table.ForeignKey(
                        name: "FK_Reading_Sensor_SensorSensorId_SensorIP",
                        columns: x => new { x.SensorSensorId, x.SensorIP },
                        principalTable: "Sensors",
                        principalColumns: new[] { "SensorId", "IP" },
                        onDelete: ReferentialAction.Restrict);
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
