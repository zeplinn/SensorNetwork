using SensorNetwork.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Models.Entities
{
    public class Sensor:EntityMigrator
    {
        
        public int SensorId { get; set; }
        [Column(TypeName ="bigint")]
        public long IP { get; set; }
        [Column(TypeName = "varchar(25)")]        
        public string Tag { get; set; }
        [EnumDataType(typeof(ESensor))]
        public ESensor SensorType { get; set; }
        public ICollection<Reading> Readings { get; set; }

        internal override void DefineEntityParameters(ModelBuilder builder)
        {
            builder.Entity<Sensor>(e =>
            {
                e.ForNpgsqlToTable("Sensors");
                e.HasKey(key=>new { key.SensorId, key.IP });
                e.Property(s => s.SensorId).ValueGeneratedOnAdd();
            });
        }
    }
}