using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Movie
    {
        public Movie() { }
        public Movie(int Mid, string name, int dur)
        {
            this.MovieId = Mid;
            this.Name = name;
            this.Duration = dur;
        }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

    }

    public class DetailedMovie
    {
        public DetailedMovie() { }
        public DetailedMovie(Movie movie)
        {
            this.Movie = movie;
        }
        public Movie Movie { get; set; }

        public override string ToString()
        {
            return "Movie: " + Movie.Name + ", duration: " + Movie.Duration + "min";
        }
    }
}
