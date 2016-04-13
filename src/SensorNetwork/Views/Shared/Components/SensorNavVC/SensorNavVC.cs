using Microsoft.AspNet.Mvc;
using SensorNetwork.Models.Entities;
using SensorNetwork.Views.Shared.Components.SensorNavVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.Views.Shared.Components.SensorNavVC
{
    public class SensorNavVC:ViewComponent
    {
        public IViewComponentResult Invoke(Sensor sensor, int networkId)
        {
            return View(new SensorNavVCModel() { Sensor = sensor, NetworkId = networkId });
        }
    }
}
