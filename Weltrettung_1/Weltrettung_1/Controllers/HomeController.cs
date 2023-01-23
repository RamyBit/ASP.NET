using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Weltrettung_1.Models;

namespace Weltrettung_1.Controllers
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
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form(HeroResponse heroResponse)
        {
            Repository.AddResponse(heroResponse);
            return View("Thanks",heroResponse);
        }
        [HttpGet]
        public IActionResult BedrohungForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BedrohungForm(Danger danger)
        {
            return View();
        }
        public IActionResult ListResponses()
        {
            return View(Repository.Responses);
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
