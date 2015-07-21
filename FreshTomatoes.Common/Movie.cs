using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshTomatoes.Common
{
    public class Movie
    {
        public Movie()
        { }
        public Movie(int id, string name, string url, double rating, string description)
        {
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
