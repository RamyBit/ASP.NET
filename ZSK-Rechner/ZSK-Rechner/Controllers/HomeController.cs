using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZSK_Rechner.Models;

namespace ZSK_Rechner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FormEuro()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult FormEuro(Waehrungsrechner waehrungsrechner)
        {
            int[] ergebniss = Waehrungsrechner.BerechneEuroInZSK(waehrungsrechner.Betrag);
            return View("ResultZSK", ergebniss);
        }
        [HttpGet]
        public IActionResult FormZSK()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult FormZSK(Waehrungsrechner waehrungsrechner)
        {
            double result = Waehrungsrechner.BerechneZSKInEuro(waehrungsrechner.Kuh, waehrungsrechner.Schaf,
                                                                waehrungsrechner.Ziege, waehrungsrechner.KleineZiege);
            return View("ResultEuro", result);
        }
        [HttpGet]
        public IActionResult FormEuroInDAHRS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormEuroInDAHRS(string betrag)
        {
            int[] result = DAHRSReschner.EuroInDAHRS(betrag);
            return View("ResultDAHRS",result);
        }
        public IActionResult FormDHRS()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}