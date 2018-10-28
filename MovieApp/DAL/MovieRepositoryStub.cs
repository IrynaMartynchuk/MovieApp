using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieApp.DAL
{
    public class MovieRepositoryStub: DAL.IMovieRepository
    {
        public List<Movie> retrieveAll()
        {
            var movieList = new List<Movie>();
            var movie = new Movie(){
                                             Id = 1,
                                             ImageAddress = "imageaddress.jpg",
                                             Title = "Title",
                                             Description = "Blockbaster Nr.1",
                                             Price = 150,
                                             Genre = "Fantasy",
                                    };
            movieList.Add(movie);
            movieList.Add(movie);
            movieList.Add(movie);
            return movieList;
        }

        public bool addMovie(Movie inMovie)
        {
            if(inMovie.Title == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool editMovie(int id, Movie movie)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Movie viewDetails(int id)
        {
            var movie = new Movie()
            {
                Id = 1,
                ImageAddress = "movieImageAddress.jpg",
                Title = "Title",
                Description = "Blockbaster",
                Price = 12,
                Genre = "Fantasy"
            };
            if (id == 0)
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
                    Price = movie.Price,
                    Genre = movie.Genre
                };
                return details;
                }
        }




    }
}
