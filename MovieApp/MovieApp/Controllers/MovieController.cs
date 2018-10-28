using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.BLL;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private IMovieBLL _movieBLL;
        public MovieController()
        {
            _movieBLL = new MovieBLL();
        }
        public MovieController(MovieBLL stub)
        {
            _movieBLL = stub;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _movieBLL.addMovie(newMovie);
                if (insertOK)
                {
                    return RedirectToAction("ListMovies");
                }
            }
            return View();
        }

        public ActionResult ListMovies()
        {
            List<Movie> allMovies = _movieBLL.retrieveAll();
            return View(allMovies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _movieBLL.viewDetails(id);
            return View(movie);
        }

        public ActionResult EditMovie(int id)
        {
            Movie movie = _movieBLL.viewDetails(id);
            return View(movie);
        }


        [HttpPost]
        public ActionResult EditMovie(int id, Movie inMovie)
        {
            if (ModelState.IsValid)
            {
              
                bool changeOK = _movieBLL.editMovie(id, inMovie);
                if (changeOK)
                {
                    return RedirectToAction("ListMovies");
                }
                else
                {
                    ViewData["test"] = "change is not ok";
                    return View();
                }
            }
            else
            {
                ViewData["test"] = "state is not valid";
            }
            return View();
        }
    }
}