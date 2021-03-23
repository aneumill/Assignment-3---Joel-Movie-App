using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonMovieApp_AdamNeumiller.Models
{
    //DB context file, where tables are added to the DB
    public class MovieDBContext : DbContext
    {
        //Constructor. The options are the list of things that are being passed into the DB
        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options)
        {

        }
        //Creates a DB Table from the movie model
        public DbSet<Movie> Movie { get; set; }
    }
}
