using FreshTomatoes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreshTomatoes.Business
{
    public interface IMovieManager
    {
        List<Movie> GetAllMovies();

        Movie GetMovie(int id);

        bool AddMovie(Movie movie);

        List<Movie> GetAllMoviesCustom(int pageIndex, int pageSize);


        bool UpdateMovie(Movie movie);

        bool DeleteMovie(int id);
    }
}
