using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Models.Entities
{

    public class Network
    {
        public int NetworkId { get; set; }        
        [Column(TypeName ="varchar(45)")]
        public string NetworkName { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Host { get; set; }
        [Column(TypeName ="varchar(16)")]
        public string Password { get; set; }
        
        public ICollection<Sensor> Sensors { get; set; }

        
    }
}
