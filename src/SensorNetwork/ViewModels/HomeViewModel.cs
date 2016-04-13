using SensorNetwork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.ViewModels
{
    public class HomeViewModel
    {
        public object Sensor { get; internal set; }
        public HomeViewModel()
        {
            PostSensorId = new Stack<string>();
        }
        public IEnumerable<Network> Networks { get; internal set; }
        public Stack<string> PostSensorId { get; set; }
        public Dictionary<string,IEnumerable<Reading>> Readings { get; set; }
        
    }
}
