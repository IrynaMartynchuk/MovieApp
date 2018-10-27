using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;


namespace MovieApp.BLL
{
    public class MovieBLL : BLL.IMovieBLL
    {
        private IMovieRepository _repository;

        public MovieBLL()
        {
            _repository = new MovieDAL();
        }

        public MovieBLL(IMovieRepository stub)
        {
            _repository = stub;
        }


        public List<Movie> retrieveAll()
        {
            List<Movie> allMovies = _repository.retrieveAll();
            return allMovies;
        }

        public Movie viewDetails(int id)
        {
            return _repository.viewDetails(id);
        }

        public bool editMovie(int id, Movie inMovie)
        {
            return _repository.editMovie(id, inMovie);
        }

        public bool addMovie(Movie newMovie)
        {
            bool insertOK = _repository.addMovie(newMovie);
            return insertOK;
        }

        /*
        public bool deleteMovie(int id)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.deleteMovie(id);
        } */
       
    }
}
