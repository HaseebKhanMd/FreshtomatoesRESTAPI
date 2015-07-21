using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreshTomatoes.Business.Tests
{
     [TestClass]
    public class MovieManagerTest
    {
         [TestMethod]
         public void GetAllMovie()
         {
             IMovieManager manager = new MovieManager();
             var result = manager.GetAllMovies();

             Assert.AreEqual(result.Count, 10);
         }

            

         [TestMethod]
         public void GetMovie()
         {
             IMovieManager manager = new MovieManager();
             var result = manager.GetMovie(1);

             Assert.AreEqual(result.Id, 1);
             Assert.AreEqual(result.Name, "Avengers - Age of Ultron");
         }

         [TestMethod]
         public void GetAllMoviePaging()
         {
             IMovieManager manager = new MovieManager();
             var result = manager.GetAllMoviesCustom(2,3);

             Assert.AreEqual(result.Count, 3);
             Assert.AreEqual(result[0].Name, "The Imitation Game");
         }


         [TestMethod]
         public void CreateMovie()
         {
             IMovieManager manager = new MovieManager();
             Common.Movie movie = new Common.Movie
             {
                 Id = 11,
                 Name = "MovieName",
                 Description = "SomeDescription",
                 Rating = 4.0,
                 URL = "http://someurl/img.png"
             };
             bool result = manager.AddMovie(movie);
             Common.Movie newMovie = manager.GetMovie(11);
             manager.DeleteMovie(11);

             Assert.IsTrue(result);
             Assert.AreEqual(newMovie.Name, "MovieName");
         }


         [TestMethod]
         public void UpdateMovie()
         {
             IMovieManager manager = new MovieManager();
             Common.Movie movie = new Common.Movie
             {
                 Id = 10,
                 Name = "MovieName",
                 Description = "SomeDescription",
                 Rating = 4.0,
                 URL = "http://someurl/img.png"
             };
             bool result = manager.UpdateMovie(movie);
             Common.Movie newMovie = manager.GetMovie(10);
            
             Assert.IsTrue(result);
             Assert.AreEqual(newMovie.Name, "MovieName");
         }

         [TestMethod]
         public void DeleteMovie()
         {             
             IMovieManager manager = new MovieManager();
             Common.Movie movie = new Common.Movie
             {
                 Id = 11,
                 Name = "MovieName",
                 Description = "SomeDescription",
                 Rating = 4.0,
                 URL = "http://someurl/img.png"
             };
             bool result1 = manager.AddMovie(movie);
             bool result = manager.DeleteMovie(11);

             Assert.IsTrue(result);
             Common.Movie newMovie = manager.GetMovie(11);
             Assert.AreEqual(newMovie, null);
         }
    }
}
