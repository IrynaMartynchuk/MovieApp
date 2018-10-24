using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;


namespace MovieApp.BLL
{
    public class MovieBLL
    {
        public List<Movie> retrieveAll()
        {
            var MovieDAL = new MovieDAL();
            List<Movie> allMovies = MovieDAL.retrieveAll();
            return allMovies;
        }

        public Movie viewDetails(int id)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.viewDetails(id);
        }

        public bool editMovie(int id, Movie inMovie)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.editMovie(id, inMovie);
        }

        public bool deleteMovie(int id)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.deleteMovie(id);
        }
        

    }
}
