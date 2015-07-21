using FreshTomatoes.Business;
using FreshTomatoes.Common;
using FreshTomatoesWebAPI.Filters;
using FreshTomatoesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreshTomatoesWebAPI.Controllers
{
    /*
    Get  /api/v1/Movies
    ---------------------------------------------------
    Action	                Method	            URI
    --------------------------------------------------- 
    Get all the Movies	    GET	                /api/v1/Movies
    Get a single Movie	    GET	                /api/v1/Movies/id
    Create a new Movie	    POST	            /api/v1/Movies
    Edit a Movie	        PUT	                /api/v1/Movies/id
    Delete a Movie	        DELETE	            /api/v1/Movies/id
    Get movies with         GET                 /api/v1/Movies?p    
     pagination
     * 
     * 
     * */
    
    public class MoviesController : ApiController
    {
        private IMovieManager movieManager;

        private MoviesController()
        {
        }

        public MoviesController(IMovieManager movManager)
        {
            movieManager = movManager;        
        }

        // GET: api/Movies
        [HttpGet]        
        public IEnumerable<MovieModel> Get()
        {
            // Use Factory or IoC to Load the instance of MovieManager
            List<Movie> movieList = movieManager.GetAllMovies();
            if (movieList != null)
                return ModelFactory.Create(movieList);
            else
                return new List<MovieModel>();
        }

        [HttpGet]  
        // GET: api/Movies/5
        public HttpResponseMessage Get(int id)
        {
            Movie movie = movieManager.GetMovie(id);
            if (movie == null)
            {
                var message = string.Format("Product with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(movie));

        }

        // POST: api/Movies
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Movie movie)
        {
            bool isValid = Validate(movie);
            if (isValid == false)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Movie Name is missing");
            else
            {
                bool isSuccess = movieManager.AddMovie(movie);
                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.Created, movie);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
            }
        }

        // PUT: api/Movies/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Movie movie)
        {
            bool isSuccess = movieManager.UpdateMovie(movie);
            if (isSuccess)
                return Request.CreateResponse(HttpStatusCode.Created, movie);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not save to the database.");
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            bool isSuccess = movieManager.DeleteMovie(id);
            if (isSuccess)
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not save to the database.");
        }


        public IEnumerable<MovieModel> Get(int pageIndex, int pageSize)
        {
            // Use Factory or IoC to Load the instance of MovieManager
            List<Movie> movieList = movieManager.GetAllMoviesCustom(pageIndex, pageSize);
            if (movieList != null)
                return ModelFactory.Create(movieList);
            else
                return new List<MovieModel>();
        }


        private bool Validate(Movie movie)
        { 
            // Add Model Validation Here or call Biz Validation Method
            if (string.IsNullOrEmpty(movie.Name))
                return false;

            return true;
        }

      
    }
}
