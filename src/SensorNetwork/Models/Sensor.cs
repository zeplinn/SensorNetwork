using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorNetwork.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        
        public long IP { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength]
        public string Tag { get; set; }
        [EnumDataType(typeof(ESensor))]
        public ESensor SensorType { get; set; }
        public ICollection<Reading> Readings { get; set; }

    }
}