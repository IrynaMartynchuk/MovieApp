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
           // var MovieDAL = new MovieDAL();
            List<Movie> allMovies = _repository.retrieveAll();
            return allMovies;
        }

        public Movie viewDetails(int id)
        {
           // var movieDAL = new MovieDAL();
            return _repository.viewDetails(id);
        }

        public bool editMovie(int id, Movie inMovie)
        {
            //var MovieDAL = new MovieDAL();
            return _repository.editMovie(id, inMovie);
        }

        public bool addMovie(Movie newMovie)
        {
            //var movieDAL = new MovieDAL();
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
