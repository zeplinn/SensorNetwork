using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SensorNetwork.Models.Entities;

namespace SensorNetwork.Models.RepositoryPattern
{
    public interface ISensorNetRepository
    {
        IEnumerable<Network> GetAllNetWork();
        IEnumerable<Network> GetAllNetworksWithSensors();
        IEnumerable<TResult> GetAllNetworksWithSensors<TResult>(Expression<Func<Network, TResult>> resultSelector);
        IEnumerable<Reading> GetReadings(Sensor sensor);
        IEnumerable<TResult> GetReadings<TResult>(Sensor sensor, Expression<Func<Reading, TResult>> select);
        int ReadingsCount();
    }
}