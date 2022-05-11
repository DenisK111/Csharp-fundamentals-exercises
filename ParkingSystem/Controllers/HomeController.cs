using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(DataAccess.Cars);
        }

        

        
    }
}
