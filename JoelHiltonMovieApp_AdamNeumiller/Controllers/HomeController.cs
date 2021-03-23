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

        //Instantiate the MovieDBContext as _context
        private MovieDBContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDBContext con)
        {
            _logger = logger;
            _context = con;



        }

        //Index page view get
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Baconsale()
        {
            return View();
        }
        //The ASP-Action for the AddMovie page (GET)
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        //The ASP-Action for the AddMovie page (Post), the form submission is passed 
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
                    //Returns the confirmation.cshtml page
                    return View("Confirmation");

                }
            }
            else
            {
                //Returns the page with the passed form
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
                    //Returns EditConfirmation page

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
            //instantiate a querable movie object equal to the DBcontextfile where the movie ID equals the passed in form
            IQueryable<Movie> queryable = _context.Movie.Where(p => p.MovieID == formsubmission.MovieID);
            //Loop through the querable object and remove all data where those MovieIDs match
            foreach (var x in queryable)
            {
                _context.Movie.Remove(x);
            }
            _context.SaveChanges();
            //Return the delete confirmation page
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
            //Returns the edit move view
            return View("EditMovie", formsubmission);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
