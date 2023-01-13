using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();
            foreach ( Product p in Product.GetProducts())
            {
                string name = p?.Name;
                decimal? price = p?.Price;
                string realtedName = p?.Related?.Name;
                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, realtedName));
            }
            return View(results);
        }
    }
}
