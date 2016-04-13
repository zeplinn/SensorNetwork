using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Models.Entities
{
    public class Reading
    {
        [Column(TypeName = "bigint")]
        public long ReadingID { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public int Value { get; set; }

        public DateTime Time { get; set; }


    }
}