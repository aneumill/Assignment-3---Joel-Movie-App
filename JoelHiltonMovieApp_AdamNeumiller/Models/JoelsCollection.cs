using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonMovieApp_AdamNeumiller.Models
{
    public static class JoelsCollection
    {
        private static List<AddMovieResponse> movies = new List<AddMovieResponse>();

        public static IEnumerable<AddMovieResponse> MovieCollection => movies; 

        public static void AddMovie(AddMovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
