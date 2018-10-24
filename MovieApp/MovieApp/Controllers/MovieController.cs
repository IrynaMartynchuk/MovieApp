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
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            var db = new MovieBLL();
            List<Movie> allMovies = db.retrieveAll();
            return View(allMovies);
        }

        public ActionResult Details(int id)
        {
            var db = new MovieBLL(); //change to CustomerBLL
            Movie movie = db.viewDetails(id);
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var db = new MovieBLL();
            Movie movie = db.viewDetails(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(int id, Movie inMovie)
        {
            if (ModelState.IsValid)
            {
                var db = new MovieBLL();
                bool changeOK = db.editMovie(id, inMovie);
                if (changeOK)
                {
                    return RedirectToAction("List<ovies");
                }
                else
                {
                    ViewBag.Message = "Some mistake occured";
                }
            }
            else
            {
                ViewBag.Message = "Some mistake occured";
            }
            return View();
        }
        
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
        }

    }
}