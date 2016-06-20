using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SensorNetwork.Models.RepositoryPattern;
using SensorNetwork.Models.Entities;
using SensorNetwork.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorNetwork.Controllers.Api
{
    [Route("api/graph")]
    public class GraphController : Controller
    {
        private ISensorNetRepository _repo;
        private Random _rnd;

        public GraphController(ISensorNetRepository repo)
        {
            _rnd = new Random();
            _repo = repo;
        }
        // GET: /<controller>/
        [HttpPost("post")]
        public  JsonResult Post([FromBody]Sensor sensor)
        {
            var valuepairs= _repo.GetReadings(sensor, r => new object[] { r.Time.TimeOfDay.TotalMilliseconds, r.Value });
            
            return new JsonResult(valuepairs);
        }
        [HttpGet("update")]
        public JsonResult Update()
        {
            var cpu = _rnd.Next(0, 100);
            return new JsonResult(new
            {
                Cpu = cpu,
                Core = cpu - 30 < 0 ? 0 : _rnd.Next(0, cpu - 30),
                Disk = _rnd.Next(56, 1024)
            });
        }

        [HttpGet("networksWithSensors")]
        public JsonResult NetworksWithSensors()
        {
            //var values = _repo.GetAllNetWork();
            var net= _repo.GetAllNetworksWithSensors(n=> new
            {
                n.Id
                , n.Name
                , Sensors=n.Sensors.Select(s=> new {s.Id, s.Tag})
            });
            return new JsonResult(net);
        }
    }
}
