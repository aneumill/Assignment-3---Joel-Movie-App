using JoelHiltonMovieApp_AdamNeumiller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

/* I DOUBLE FILTERED IN MY CODE. I DON'T ALLOW INDEPENEDNCE DAY TO BE STORED AT ALL WITH THE ACTION ADDMOVIE(). I ALSO DO NOT ALLOW IT TO BE DISPLAYED
 
 AS SHOWN IN THE MYMOVIES() ACTION. */



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
                //THIS IS THE FIRST FILTER. IF THE MODEL IS VALID THEN IT DROPS IN TO THE IF STATEMENT. IF THE VALUE IS INDPENDENCE DAY THEN IT 
                // RETURNS A VIEW SAYING THAT IT COULD NOT BE ADDED. IF IT IS NOT INDPENDENCE DAY THEN THEN A VIEW IS RETURNED SAYING THAT THE 
                // FORM WAS SUCESSFULLY SUBMITED. THE OTHER FILTER USING LINQ IS SHOWN BELOW. 
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

       


        //THIS IS ME FUFILLLING THE FILTERING PART WITH INDEPENDENCE DAY USING LINQ, PER WHAT I WAS ABLE TO FIGURE OUT IN THE TEXTBOOK.
        public IActionResult MyMovies()
        {
            //linq filtering
             return View(JoelsCollection.MovieCollection.Where(r => r.Title.ToUpper() != "INDEPENDENCE DAY"));
             


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
