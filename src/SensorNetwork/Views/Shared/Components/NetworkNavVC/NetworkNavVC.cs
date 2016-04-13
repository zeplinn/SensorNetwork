using Microsoft.AspNet.Mvc;
using SensorNetwork.Models.Entities;
using SensorNetwork.Views.Shared.Components.NetworkNavVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorNetwork.Views.Shared.Components.NetworkNavVC
{
    public class NetworkNavVC: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Network network, string dataParent)
        {
            var wait = await Task<NetworkNavVCModel>.Run(() => new NetworkNavVCModel() { Network = network, DataParent = dataParent });
            return View(wait);
            
        }
        
    }
}
