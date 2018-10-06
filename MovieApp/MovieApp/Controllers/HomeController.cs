using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("ListMovies");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer inCustomer)
        {
            if (ModelState.IsValid)
            {
                var Db = new DBCustomer();
                bool insertOK = Db.saveCustomer(inCustomer);
                if (insertOK)
                {
                    return RedirectToAction("RegistrationOK");
                }
            }
            ViewBag.Message = "Some mistake occured or user with such email already exists!";
            return View();
        }

        public ActionResult RegistrationOK()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            if (Session["Cart"] == null || (bool)Session["Cart"] == false)
            {
                string sessionId = this.Session.SessionID;
                Order newOrder = new Order
                {
                    Date = DateTime.Now,
                    Confirmed = false,
                    SessionId = sessionId
                };
                var db = new DBContext();
                db.Orders.Add(newOrder);
                db.SaveChanges();
                Session["Cart"] = true;
            }
            var Db = new DBMovie();
            List<Movie> allMovies = Db.retrieveAll();
            return View(allMovies);
        }

        public int addToCart(int MovieId)
        {

            var db = new DBContext();
            var amountOflines = 0;
            if (Session["Cart"] != null)
            {
                var newOrderline = new Orderline
                {
                    Antall = 1,
                    MovieId = MovieId,
                    OrderId = (from order in db.Orders where this.Session.SessionID == order.SessionId select order.Id).First()
                };
                if (checkOrderline(newOrderline))
                {
                    var count = 0;
                    var orderlines = new List<Orderline>();
                    orderlines.Add(newOrderline);
                    count++;
                    count = amountOflines;
                }
                else
                {
                    ViewBag.Error = "Item is already added to your cart!";
                }

            }
            return amountOflines;
        }

        public bool checkOrderline(Orderline newOrderline)
        {
            var db = new DBContext();
            var existingMovieId = db.Orderlines.Where(a => a.MovieId == newOrderline.MovieId).SingleOrDefault();
            if (existingMovieId == null)
            {
                try
                {
                    db.Orderlines.Add(newOrderline);
                    db.SaveChanges();
                }
                catch (Exception error)
                {

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult Cart()
        {
            var db = new DBContext();
            var orderId = (from order in db.Orders where this.Session.SessionID == order.SessionId select order.Id).First();
            var orderlines = (from list in db.Orderlines where list.OrderId == orderId select list.MovieId).ToList();
            var movies = (from movie in db.Movies.AsEnumerable()
                          where orderlines.Contains(movie.Id)
                          select new Movie
                          {
                              Id = movie.Id,
                              ImageAddress = movie.ImageAddress,
                              Title = movie.Title,
                              Price = movie.Price,
                              Genre = movie.Genre

                          }).ToList();
            var sum = 0;
            foreach (var movie in movies)
            {
                ViewBag.TotalPrice = sum + movie.Price;
            }
            return View(movies);
        }

        public bool Delete(int id)
        {
            using (var db = new DBContext())
            {

                try
                {
                    var orderlineId = (from lines in db.Orderlines where lines.MovieId == id select lines.Id);
                    var line = db.Orderlines.Find(orderlineId);
                    db.Orderlines.Remove(line);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }

        }

        public ActionResult Login()
        {
            if (Session["customer"] != null)
            {
                return RedirectToAction("ListMovies", "Home", new { customer = Session["customer"].ToString() });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Customer Customer)
        {
            DBContext db = new DBContext();
            var loggedIn = db.Customers.SingleOrDefault(c => c.Email == Customer.Email && c.Password == Customer.Password);

            if (loggedIn != null)
            {
                ViewBag.triedOnce = true;
                Session["customer"] = Customer.Id;
                ViewBag.Message = "You are logged in";
                return RedirectToAction("ListMovies", "Home", new { customer = loggedIn.Id });
            }
            else
            {
                ViewBag.triedOnce = true;
                return View(); //if failed - error message 
            }
        }

        public ActionResult Logout()
        {
            if (Session["customer"] != null)
            {
                Session["customer"] = null;
                return RedirectToAction("ListMovies", "Home");
            }
            else
            {
                return RedirectToAction("ListMovies", "Home", new { customer = Session["customer"].ToString() });
            }

        }

        public string Confirmation()
        {
            if(Session["customer"] == null)
            {
                var message = "In order to procceed you need to log in!";
                return message;
            }
            var ok = "You will receive confirmation email with receipt!";
            return ok;
        }


    }
}