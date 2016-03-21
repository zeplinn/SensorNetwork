using Microsoft.Data.Entity;
using SensorNetwork.Models.DbContexts;
using SensorNetwork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.Models.RepositoryPattern
{
    public class SensorNetRepository : ISensorNetRepository
    {
        private SensorNetContext _context;
        
        public SensorNetRepository( SensorNetContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Network> GetAllNetWork()
        {
            try
            {
                return _context.Networks.OrderBy(t => t.NetworkName);
            }
            catch (Exception e)
            {

                return new Network[0];
            }
        }
        public IEnumerable<Network> GetAllNetworksWithSensors()
        {
            try
            {
                return _context
                    .Networks
                    .Include(t => t.Sensors)
                    .OrderBy(t => t.NetworkName)
                    .ToList();
            }
            catch (Exception e)
            {

                return new Network[0];
            }
        }

        public IEnumerable<int> SensorData(Network n, Sensor s)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ReadingsCount()
        {
            return _context.Readings.Count();
        }
        //private IEnumerable<T> ErrorHandling<T>() where T : Nullable
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //    return new T[0];
        //}
    }
}
