using Microsoft.Data.Entity;
using SensorNetwork.Models.DbContexts;
using SensorNetwork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SensorNetwork.Models.RepositoryPattern
{
    public class SensorNetRepository : ISensorNetRepository
    {
        private SensorNetContext _context;
        public SensorNetRepository(SensorNetContext context)
        {

            context.Database.EnsureCreated();
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
       
        public IEnumerable<TResult> GetAllNetworksWithSensors<TResult>( Expression<Func<Network, Sensor, TResult>> resultSelector)
        {
            try
            {
                var a = _context
                    .Networks
                    .Include(n => n.Sensors)
                    .OrderBy(n => n.NetworkName).SelectMany(n=>n.Sensors,resultSelector).ToList();
                return a;
               // SelectMany(n => n.Sensors, (n, s) => new { netId = n.NetworkId, sensor = new { senId = s.SensorId, SensorTag = s.Tag } });
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public IEnumerable<Network> GetAllNetworksWithSensors()
        {
            try
            {
                var a = _context
                    .Networks
                    .Include(n => n.Sensors)
                    .OrderBy(n => n.NetworkName).ToList();
                return a;
                // SelectMany(n => n.Sensors, (n, s) => new { netId = n.NetworkId, sensor = new { senId = s.SensorId, SensorTag = s.Tag } });
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public int ReadingsCount()
        {
            return _context.Readings.Count();
        }

        public IEnumerable<Reading> GetReadings(Sensor sensor)
        {            
            return _context.Readings.Where(r=>r.SensorId==sensor.SensorId).ToList();
        }
        public IEnumerable<TResult> GetReadings<TResult>(Sensor sensor, Expression<Func<Reading,TResult>> select)
        {
            return _context.Readings.Where(r => r.SensorId == sensor.SensorId).OrderBy(r => r.Time).Select(select).ToList();
        }
        
    }
}
