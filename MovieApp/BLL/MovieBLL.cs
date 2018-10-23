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

        public bool editMovie(int id, Movie inMovie)
        {
            var MovieDAL = new MovieDAL();
            return MovieDAL.editMovie(id, inMovie);
        }

        public Movie viewDetails(int id)
        {
            var MovieDAL = new MovieDAL();
            return MovieDAL.viewDetails(id);
        }

        public bool deleteMovie(int id)
        {
            var MovieDAL = new MovieDAL();
            return MovieDAL.deleteMovie(id);
        }

        public bool saveMovie(Movie inMovie)
        {
            var MovieDAL = new MovieDAL();
            bool insertOK = MovieDAL.saveMovie(inMovie);
            return insertOK;
        }
    }
}
