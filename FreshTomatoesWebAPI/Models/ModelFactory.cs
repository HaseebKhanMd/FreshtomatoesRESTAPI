using FreshTomatoes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreshTomatoesWebAPI.Models
{
    public class ModelFactory
    {
        public static MovieModel Create(Movie movie)
        { 
            return new MovieModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                URL = movie.URL,
                Rating = movie.Rating,
                Description = movie.Description
            };      
        }

        internal static IEnumerable<MovieModel> Create(List<Movie> movieList)
        {
            var movies = from movie in movieList
                         select new MovieModel
                         {
                             Id = movie.Id,
                             Name = movie.Name,
                             URL = movie.URL,
                             Rating = movie.Rating,
                             Description = movie.Description
                         };

            return movies;
        }
    }
}