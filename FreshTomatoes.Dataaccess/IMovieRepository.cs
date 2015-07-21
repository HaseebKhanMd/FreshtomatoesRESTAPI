using FreshTomatoes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreshTomatoes.DataAccess
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();

        List<Movie> GetAllMoviesCustom(int pageIndex, int pageSize );

        Movie GetMovie(int id);

        bool AddMovie(Movie movie);

        bool UpdateMovie(Movie movie);

        bool DeleteMovie(int id);
    }
}
