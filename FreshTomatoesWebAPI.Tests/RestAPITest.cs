using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreshTomatoesWebAPI.Controllers;
using FreshTomatoes.Business;
using System.Collections.Generic;
using FreshTomatoesWebAPI.Models;

namespace FreshTomatoesWebAPI.Tests
{
    [TestClass]
    public class RestAPITest
    {
        [TestMethod]
        public void TestGet()
        {
            IMovieManager manager = new MovieManager();
            MoviesController controller = new MoviesController(manager);
            var res = controller.Get() ;
            var result = new List<MovieModel>(res);
            Assert.AreEqual(result.Count, 10);
        }

        // TODO Add other tests

    }

}
