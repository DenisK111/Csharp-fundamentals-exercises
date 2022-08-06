using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateWebApp.Models;
using Services.Contracts;

namespace RealEstateWebApp.Controllers
{
    public class ServicesController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly RealEstateContext context;
        private readonly IPropertyService service;

        public ServicesController(ILogger<HomeController> logger, RealEstateContext context,IPropertyService service)
        {
            _logger = logger;
            this.context = context;
            this.service = service;
        }

        public IActionResult Property()
        {

            return View();
        }
        public IActionResult PropertyResult(int from,int to)
        {
            decimal result = service.GetAvaragePriceBySquareMeters(from, to);
            return View(new PropertyResultViewModel() { result = result});
        }
    }
}
