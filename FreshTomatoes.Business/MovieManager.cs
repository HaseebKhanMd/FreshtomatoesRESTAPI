using FreshTomatoes.Common;
using FreshTomatoes.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshTomatoes.Business
{
    public class MovieManager : IMovieManager
    {
        //TODO// Use Factory or IoC Pattern to Get the Instance of MovieRepository
        IMovieRepository movieReporsitory = MovieRepository.Instance;
        public List<Movie> GetAllMovies()
        {
            try
            {
                return movieReporsitory.GetAllMovies();
            }
            catch(Exception)
            {
                //LogException here 
                //ExceptionHandler.HandleException(ex,ExceptionHandler.Policy.Business);
                return null;
            }
        }

        public Movie GetMovie(int id)
        {
            try
            {
                return movieReporsitory.GetMovie(id);
            }
            catch (Exception)
            {
                //LogException here 
                //ExceptionHandler.HandleException(ex,ExceptionHandler.Policy.Business);
                return null;
            }
        }

        public bool AddMovie(Movie movie)
        {
            try
            {
                return movieReporsitory.AddMovie(movie);  
            }
            catch (Exception)
            {
                //LogException here 
                //ExceptionHandler.HandleException(ex,ExceptionHandler.Policy.Business);                
            }
            return false;  
        }

        public bool UpdateMovie(Movie movie)
        {
            try
            {
                return movieReporsitory.UpdateMovie(movie);
            }
            catch (Exception)
            {
                //LogException here 
                //ExceptionHandler.HandleException(ex,ExceptionHandler.Policy.Business);                
            }
            return false;  
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                return movieReporsitory.DeleteMovie(id);
            }
            catch (Exception)
            {
                //LogException here 
                //ExceptionHandler.HandleException(ex,ExceptionHandler.Policy.Business);                
            }
            return false;              
        }

        public List<Movie> GetAllMoviesCustom(int pageIndex, int pageSize )
        {
            try
            {
                return movieReporsitory.GetAllMoviesCustom(pageIndex, pageSize);
            }
            catch (Exception)
            {
                //LogException here 
                //ExceptionHandler.HandleException(ex,ExceptionHandler.Policy.Business);                
            }
            return null;          
            
        }   
    }
}
