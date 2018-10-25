using System;
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

        public Movie viewDetails(int id)
        {
            using (var db = new DBContext())
            {
                var movie = db.Movies.Find(id);

                if (movie == null)
                {
                    return null;
                }
                else
                {
                    var details = new Movie()
                    {
                        Id = movie.Id,
                        ImageAddress = movie.ImageAddress,
                        Title = movie.Title,
                        Description = movie.Description,
                        Price = movie.Price
                    };
                    return details;
                }
            }
        }

        public bool editMovie(int id, Movie movie)
        {
            var db = new DBContext();
            var result = db.Movies.Find(id);

            if (result != null)
            {
                result.ImageAddress = movie.ImageAddress;
                result.Title = movie.Title;
                result.Description = movie.Description;
                result.Price = movie.Price;
                result.Genre = movie.Genre;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public bool addMovie(Movie inMovie)
        {
            var newMovie = new Movie()
            {
                ImageAddress = inMovie.ImageAddress,
                Title = inMovie.Title,
                Description = inMovie.Description,
                Price = inMovie.Price,
                Genre = inMovie.Genre
        };

            using (var db = new DBContext())
            {
                try
                {
                    db.Movies.Add(newMovie);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


        /*
        public bool deleteMovie(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Movie movie = db.Movies.Find(id);
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        } */
    }
}