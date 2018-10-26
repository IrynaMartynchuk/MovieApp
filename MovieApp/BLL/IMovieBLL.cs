using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public interface IMovieBLL
    {
        bool addMovie(Movie newMovie);
        bool editMovie(int id, Movie inMovie);
        List<Movie> retrieveAll();
        Movie viewDetails(int id);
    }
}