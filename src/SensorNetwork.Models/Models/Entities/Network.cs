using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Models.Entities
{

    public class Network
    {
        public int Id { get; set; }        
        [Column(TypeName ="varchar(45)")]
        public string Name { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Host { get; set; }
        [Column(TypeName ="varchar(16)")]
        public string Password { get; set; }
        
        public ICollection<Sensor> Sensors { get; set; }
    }
}
