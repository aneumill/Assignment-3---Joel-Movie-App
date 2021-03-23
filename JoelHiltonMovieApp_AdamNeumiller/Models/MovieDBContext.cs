using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonMovieApp_AdamNeumiller.Models
{
    public class MovieDBContext : DbContext
    {
        //Constructor. The options are the list of things that are being passed into the DB
        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options)
        {

        }
        
        public DbSet<Movie> Movie { get; set; }
    }
}
