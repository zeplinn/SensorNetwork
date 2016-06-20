using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SensorNetwork.Models.RepositoryPattern;
using SensorNetwork.ViewModels;
using SensorNetwork.Models.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorNetwork.Controllers.App
{
    public class AppController : Controller
    {
        private ISensorNetRepository _snRepo;
        private HomeViewModel _vm;

        internal static string AHome { get; } = "Home";
        internal static object C { get; } = "app";
        internal static string ASettings { get; } = "Settings";
        public AppController(ISensorNetRepository snRepo)
        {
            _vm = new HomeViewModel();
            _snRepo = snRepo;
        }
        // GET: /<controller>/
        public IActionResult Home()
        {
            _vm.Networks= _snRepo.GetAllNetworksWithSensors();
            
            return View(_vm);
        }

        //public JsonResult FetechNetworkWithSensors()
        //{
        //    var s = _snRepo.GetAllNetworksWithSensors
        //    return new JsonResult()
        //}
        public IActionResult Settings()
        {
            return View();
        }
        
    }
}
