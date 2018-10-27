using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public interface IMovieRepository
    {
        bool addMovie(Movie inMovie);
        bool editMovie(int id, Movie movie);
        List<Movie> retrieveAll();
        Movie viewDetails(int id);
    }
}