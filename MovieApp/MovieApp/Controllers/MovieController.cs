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
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        // GET: Movie

        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                //var db = new MovieBLL();
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
            //var db = new MovieBLL();
            List<Movie> allMovies = _movieBLL.retrieveAll();
            return View(allMovies);
        }

        public ActionResult Details(int id)
        {
           // var db = new MovieBLL();
            Movie movie = _movieBLL.viewDetails(id);
            return View(movie);
        }

        public ActionResult EditMovie(int id)
        {
           // var db = new MovieBLL();
            Movie movie = _movieBLL.viewDetails(id);
            return View(movie);
        }


        [HttpPost]
        public ActionResult EditMovie(int id, Movie inMovie)
        {
            if (ModelState.IsValid)
            {
               // var db = new MovieBLL();
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

        /*
        public ActionResult DeleteMovie(int id)
        {
            var db = new MovieBLL();
            Movie movie = db.viewDetails(id);
            ViewData["test"] = "DeleteMovie OK";
            return View(movie);
        }

        [HttpPost]
        public ActionResult DeleteMovie(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var db = new MovieBLL();
                bool deleteOK = db.deleteMovie(id);
                if (deleteOK)
                {

                    ViewData["test"] = "deleteOK";
                    return RedirectToAction("ListMovies");
                }
            }

            ViewData["test"] = "Delete NOT ok, some mistake occured";
            ViewBag.Message = "Some mistake occured";
            return View();
        } */

    }
}