﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public class MovieDAL
    {
        public List<Movie> retrieveAll()
        {
            using (var db = new DBContext())
            {
                List<Movie> allMovies = (from movies in db.Movies.AsEnumerable()
                                         select new Movie()
                                         {
                                             Id = movies.Id,
                                             ImageAddress = movies.ImageAddress,
                                             Title = movies.Title,
                                             Description = movies.Description,
                                             Price = movies.Price,
                                             Genre = movies.Genre
                                         }).ToList();
                return allMovies;
            }

        }
    }
}