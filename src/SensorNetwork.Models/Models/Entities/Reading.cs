using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Models.Entities
{
    public class Reading
    {   
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public int Value { get; set; }

        public DateTime Time { get; set; }


    }
}