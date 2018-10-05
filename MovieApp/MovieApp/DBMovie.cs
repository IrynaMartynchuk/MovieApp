using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;

namespace MovieApp
{
    public class DBMovie
    {
        public List<Movie> retrieveAll()
        {
            using (var db = new DBContext())
            {
                List<Movie> allMovies = db.Movies.Select(k => new Movie()
                {
                    Id = k.Id,
                    ImageAddress = k.ImageAddress,
                    Title = k.Title,
                    Description = k.Description,
                    Price = k.Price,
                    Genre = k.Genre
                }
                                    ).ToList();
                return allMovies;
            }

        }
    }
}