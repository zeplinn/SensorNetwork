using SensorNetwork.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.Models
{
    public class SeedNetwork
    {
        private SensorNetContext _snc;
        private Random Rng { get; } = new Random();
        public SeedNetwork(SensorNetContext snc)
        {
            _snc = snc;
        }

        public void ensureSeedData()
        {
            if (!_snc.Networks.Any())
            {

                for(int item=1; item<6;item++)
                {
                    var network = new Network()
                    {
                        NetworkId = item,
                        Host = $"localhost{item}",
                        NetworkName = $"Network{item}",
                        Password = $"xxxx{item}",
                        Sensors = new List<Sensor>(EnsureSensorSeed())
                    };
                    _snc.Networks.Add(network);
                }
                _snc.SaveChanges();
            }
        }
        
        private IEnumerable<Sensor> EnsureSensorSeed()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new Sensor()
                {
                    Tag = Enum.GetName(typeof(ESensor), i),
                    SensorType = (ESensor)i,
                    IP = 19216850+i,
                    Readings = new List<Reading>(EnsureReadingSeed())
                };


            }
        }
        private int sensorInc = 0;
        private IEnumerable<Reading> EnsureReadingSeed()
        {
            int min = 0;
            for (int i = 0; i < Rng.Next(30,70); i++)
            {
                
                var DateTime = new DateTime(2016, 3, 1, 0, 0, 0, 0);
                yield return new Reading()
                {
                    ReadingID=sensorInc++,
                    Time = DateTime.AddMinutes(min),
                    Value = Rng.Next(5, 30)
                };
                min += 30;
            }
        }


    }

}


    

