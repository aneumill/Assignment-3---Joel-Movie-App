using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonMovieApp_AdamNeumiller.Models
{
    public static class JoelsCollection
    {
        private static List<Movie> movies = new List<Movie>();

        public static IEnumerable<Movie> MovieCollection => movies; 

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
