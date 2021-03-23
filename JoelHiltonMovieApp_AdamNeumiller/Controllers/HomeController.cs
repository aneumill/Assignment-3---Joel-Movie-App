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

        private MovieDBContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDBContext con)
        {
            _logger = logger;
            _context = con;



        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Baconsale()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie formsubmission)
        {
            if (ModelState.IsValid)
            {
                //THIS IS THE FIRST FILTER. IF THE MODEL IS VALID THEN IT DROPS IN TO THE IF STATEMENT. IF THE VALUE IS INDPENDENCE DAY THEN IT 
                // RETURNS A VIEW SAYING THAT IT COULD NOT BE ADDED. IF IT IS NOT INDPENDENCE DAY THEN THEN A VIEW IS RETURNED SAYING THAT THE 
                // FORM WAS SUCESSFULLY SUBMITED. THE OTHER FILTER USING LINQ IS SHOWN BELOW. 


                if (formsubmission.Title.ToUpper() != "INDEPENDENCE DAY")
                {
                    _context.Movie.Add(formsubmission);
                    _context.SaveChanges();
                    return View("Confirmation", formsubmission);


                }
                else
                {

                    return View("Confirmation");

                }
            }
            else
            {
                return View(formsubmission);
            }
        }

        [HttpGet]
        public IActionResult EditMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditMovie(Movie formsubmission)
        {
            if (ModelState.IsValid)
            {
                //THIS IS THE FIRST FILTER. IF THE MODEL IS VALID THEN IT DROPS IN TO THE IF STATEMENT. IF THE VALUE IS INDPENDENCE DAY THEN IT 
                // RETURNS A VIEW SAYING THAT IT COULD NOT BE ADDED. IF IT IS NOT INDPENDENCE DAY THEN THEN A VIEW IS RETURNED SAYING THAT THE 
                // FORM WAS SUCESSFULLY SUBMITED. THE OTHER FILTER USING LINQ IS SHOWN BELOW. 


                if (formsubmission.Title.ToUpper() != "INDEPENDENCE DAY")
                {
                    _context.Movie.Update(formsubmission);
                    _context.SaveChanges();
                    return View("EditConfirmation", formsubmission);


                }
                else
                {

                    return View("EditConfirmation");

                }
            }
            else
            {
                return View(formsubmission);
            }
        }

        [HttpPost]
        public IActionResult RemoveMovie(Movie formsubmission)
        {
            IQueryable<Movie> queryable = _context.Movie.Where(p => p.MovieID == formsubmission.MovieID);
            foreach (var x in queryable)
            {
                _context.Movie.Remove(x);
            }
            _context.SaveChanges();
            return View("DeleteConfirmation");
        }

        //THIS IS ME FUFILLLING THE FILTERING PART WITH INDEPENDENCE DAY USING LINQ, PER WHAT I WAS ABLE TO FIGURE OUT IN THE TEXTBOOK.
        [HttpGet]
        public IActionResult MyMovies()
        {
            //linq filtering
             return View(_context.Movie.Where(r => r.Title.ToUpper() != "INDEPENDENCE DAY"));
             


        }
        [HttpPost]
        public IActionResult MyMovies(Movie formsubmission)
        {
            return View("EditMovie", formsubmission);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
