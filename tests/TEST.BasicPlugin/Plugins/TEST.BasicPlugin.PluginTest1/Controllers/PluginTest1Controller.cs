using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.BasicPlugin.PluginTest1.Controllers
{
    public class PluginTest1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test1()
        {
            return View();
        }

        public IActionResult Test2()
        {
            return View("~/Views/PluginTest1/ExtTest.cshtml");
        }
    }
}
