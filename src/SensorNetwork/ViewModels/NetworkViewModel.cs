using SensorNetwork.Models;
using SensorNetwork.Models.RepositoryPattern;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SensorNetwork.ViewModel 
{
    public class NetWorkViewModel : IEnumerable<Sensor>
    {
        private ISensorNetRepository _repos;

        public NetWorkViewModel(ISensorNetRepository repos)
        {
            _repos = repos;
        }
        public IEnumerator<Sensor> GetEnumerator()
        {
            foreach (Network network in _repos.GetAllNetworksWithSensors())
            {
                foreach (Sensor sensor in network.Sensors)
                {
                    yield return sensor;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}