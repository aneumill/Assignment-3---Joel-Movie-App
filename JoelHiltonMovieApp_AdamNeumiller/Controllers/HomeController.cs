using JoelHiltonMovieApp_AdamNeumiller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonMovieApp_AdamNeumiller.Controllers
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
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieResponse appResponse)
        {
            if (ModelState.IsValid)
            {

                if (appResponse.Title.ToUpper() != "INDEPENDENCE DAY")
                {
                    JoelsCollection.AddMovie(appResponse);
                    return View("Confirmation", appResponse);
                }
                else
                {
                    return View("Confirmation", appResponse);

                }
            }
            else
            {
                return View();
            }
        }
        
        
        public IActionResult MyMovies()
        {
            return View(JoelsCollection.MovieCollection);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
