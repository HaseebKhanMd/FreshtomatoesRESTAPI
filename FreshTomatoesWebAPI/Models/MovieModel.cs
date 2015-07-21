using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreshTomatoesWebAPI.Models
{
    public class MovieModel
    {
        public MovieModel()
        {

        }
        public MovieModel(int id, string name, string url, double rating, string description)
        {
            // TODO: Complete member initialization
            Id = id;
            Name = name;
            URL = url;
            Rating = rating;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }
}