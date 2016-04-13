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
                    NetworkId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Host = table.Column<string>(type: "varchar(50)", nullable: true),
                    NetworkName = table.Column<string>(type: "varchar(45)", nullable: true),
                    Password = table.Column<string>(type: "varchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.NetworkId);
                });
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    IP = table.Column<long>(type: "bigint", nullable: false),
                    InFolder = table.Column<string>(type: "varchar(25)", nullable: true),
                    NetworkId = table.Column<int>(nullable: false),
                    SensorType = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(type: "varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_Sensor_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "NetworkId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    ReadingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    SensorId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ReadingID);
                    table.ForeignKey(
                        name: "FK_Reading_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Sensor_InFolder",
                table: "Sensors",
                column: "InFolder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Readings");
            migrationBuilder.DropTable("Sensors");
            migrationBuilder.DropTable("Network");
        }
    }
}
