using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorNetwork.Controllers.App
{
    public class AppController : Controller
    {
        internal static string AHome { get; } = "Home";
        internal static object C { get; } = "app";
        internal static string ASettings { get; } = "Settings";

        // GET: /<controller>/
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
    }
}
