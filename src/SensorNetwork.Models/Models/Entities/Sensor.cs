using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Models.Entities
{
    public class Sensor
    {       
        public int Id { get; set; }
        [Column(TypeName ="bigint")]
        public long IP { get; set; }
        [Column(TypeName = "varchar(25)")]        
        public string Tag { get; set; }
        [EnumDataType(typeof(ESensor))]
        public ESensor Type { get; set; }
        public ICollection<Reading> Readings { get; set; }
        
        public Network Network { get; set; }

    }
}