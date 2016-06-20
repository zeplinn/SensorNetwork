using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SensorNetwork.Models.DbContexts;

namespace SensorNetwork.Models.Migrations
{
    [DbContext(typeof(SensorNetContext))]
    partial class SensorNetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("SensorNetwork.Models.Entities.Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Host")
                        .HasAnnotation("Relational:ColumnType", "varchar(50)");

                    b.Property<string>("Name")
                        .HasAnnotation("Relational:ColumnType", "varchar(45)");

                    b.Property<string>("Password")
                        .HasAnnotation("Relational:ColumnType", "varchar(16)");

                    b.HasKey("Id");

                    b.HasAnnotation("Npgsql:TableName", "Network");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Reading", b =>
                {
                    b.Property<DateTime>("Time");

                    b.Property<int>("SensorId");

                    b.Property<int>("Value");

                    b.HasKey("Time", "SensorId");

                    b.HasAnnotation("Npgsql:TableName", "Readings");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IP")
                        .HasAnnotation("Relational:ColumnType", "bigint");

                    b.Property<int?>("NetworkId");

                    b.Property<string>("Tag")
                        .HasAnnotation("Relational:ColumnType", "varchar(25)");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasAnnotation("Npgsql:TableName", "Sensors");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Reading", b =>
                {
                    b.HasOne("SensorNetwork.Models.Entities.Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId");
                });

            modelBuilder.Entity("SensorNetwork.Models.Entities.Sensor", b =>
                {
                    b.HasOne("SensorNetwork.Models.Entities.Network")
                        .WithMany()
                        .HasForeignKey("NetworkId");
                });
        }
    }
}
