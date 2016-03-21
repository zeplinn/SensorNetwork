using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.Models
{
    public class Network
    {
        public int NetworkId { get; set; }
        [Key]
        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string NetworkName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(45)]
        public string Host { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string Password { get; set; }
        
        public ICollection<Sensor> Sensors { get; set; }
        
        
    }
}
