
using SensorNetwork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.Views.Shared.Components.SensorNavVC
{
    public class SensorNavVCModel
    {
        public int NetworkId { get; set; }
        public Sensor Sensor { get; set; }
    }

}
