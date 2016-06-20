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
                return _context.Networks.OrderBy(t => t.Name);
            }
            catch (Exception e)
            {
                
                return new Network[0];
            }
        }
       
        public IEnumerable<TResult> GetAllNetworksWithSensors<TResult>( Expression<Func<Network, TResult>> networkSelector)
        {
            try
            {
                var a =
                    _context.Networks
                    .Include(n=>n.Sensors)
                        .Select(networkSelector);
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
                    .OrderBy(n => n.Name).ToList();
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
            return _context.Readings.Where(r=>r.Sensor.Id==sensor.Id).ToList();
        }
        public IEnumerable<TResult> GetReadings<TResult>(Sensor sensor, Expression<Func<Reading,TResult>> select)
        {
            return _context.Readings.Where(r => r.Sensor.Id == sensor.Id).OrderBy(r => r.Time).Select(select).ToList();
        }
        
    }
}
