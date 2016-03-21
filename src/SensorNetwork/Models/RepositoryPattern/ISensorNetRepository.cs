using System.Collections.Generic;

namespace SensorNetwork.Models.RepositoryPattern
{
    public interface ISensorNetRepository
    {
        IEnumerable<Network> GetAllNetWork();
        IEnumerable<Network> GetAllNetworksWithSensors();
        IEnumerable<int> SensorData(Network n, Sensor s);
    }
}