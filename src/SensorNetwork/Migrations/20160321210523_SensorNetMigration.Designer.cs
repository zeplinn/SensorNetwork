using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SensorNetwork.Models.DbContexts;

namespace SensorNetwork.Migrations
{
    [DbContext(typeof(SensorNetContext))]
    [Migration("20160321210523_SensorNetMigration")]
    partial class SensorNetMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("SensorNetwork.Models.Entities.Network", b =>
                {
                    b.Property<int>("NetworkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NetworkName")
                        .HasAnnotation("Relational:ColumnType", "varchar(45)");

                    b.Property<string>("Host")
                        .HasAnnotation("Relational:ColumnType", "varchar(50)");

                    b.Property<string>("Password")
                        .HasAnnotation("Relational:ColumnType", "varchar(16)");

                    b.HasKey("NetworkId", "NetworkName");

                    b.HasAnnotation("Npgsql:TableName", "Network");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Reading", b =>
                {
                    b.Property<long>("ReadingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnType", "bigint");

                    b.Property<long?>("SensorIP");

                    b.Property<int?>("SensorSensorId");

                    b.Property<DateTime>("Time");

                    b.Property<int>("Value");

                    b.HasKey("ReadingID");

                    b.HasAnnotation("Npgsql:TableName", "Readings");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IP")
                        .HasAnnotation("Relational:ColumnType", "bigint");

                    b.Property<int?>("NetworkNetworkId");

                    b.Property<string>("NetworkNetworkName");

                    b.Property<int>("SensorType");

                    b.Property<string>("Tag")
                        .HasAnnotation("Relational:ColumnType", "varchar(25)");

                    b.HasKey("SensorId", "IP");

                    b.HasAnnotation("Npgsql:TableName", "Sensors");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Reading", b =>
                {
                    b.HasOne("SensorNetwork.Models.Entities.Sensor")
                        .WithMany()
                        .HasForeignKey("SensorSensorId", "SensorIP");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Sensor", b =>
                {
                    b.HasOne("SensorNetwork.Models.Entities.Network")
                        .WithMany()
                        .HasForeignKey("NetworkNetworkId", "NetworkNetworkName");
                });
        }
    }
}
