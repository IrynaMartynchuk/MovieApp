﻿using System;
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

            var db = new DBContext();
            Order falseOrder = db.Orders.SingleOrDefault(x => x.SessionId != this.Session.SessionID && x.Confirmed == false); 
            if(falseOrder != null)
            {
                db.Orders.Remove(falseOrder);
                db.SaveChanges();
                
            }
            string sessionId = this.Session.SessionID;
            if (Session["Cart"] == null || (bool)Session["Cart"] == false)
                {
                    
                var orderExist = db.Orders.Where(x => x.Confirmed == false || x.SessionId == this.Session.SessionID).SingleOrDefault();
                if (orderExist == null)
                {
                    Order newOrder = new Order
                    {
                        Date = DateTime.Now,
                        Confirmed = false,
                        SessionId = sessionId
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    Session["Cart"] = true;
                }
                
                }
            else
            {
                var orderExist2 = db.Orders.Where(x => x.Confirmed == false).SingleOrDefault();
                if (orderExist2 == null)
                {
                    Order newOrder = new Order
                    {
                        Date = DateTime.Now,
                        Confirmed = false,
                        SessionId = sessionId
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }
            }
            var Db = new DBMovie();
            List<Movie> allMovies = Db.retrieveAll();
            return View(allMovies);
        }

        public int addToCart(int MovieId)
        {
            var totalAmount = 0;
            var db = new DBContext();
            if (Session["Cart"] != null)
            {

                var newOrderline = new Orderline
                {
                    Antall = 1,
                    MovieId = MovieId,
                    OrderId = (from order in db.Orders where this.Session.SessionID == order.SessionId && order.Confirmed == false select order.Id).SingleOrDefault()
                };
                if (checkOrderline(newOrderline))
                {

                    var orderlines = new List<Orderline>();
                    orderlines.Add(newOrderline);
                    totalAmount = totalAmount + 1;
                }
                else
                {
                    ViewBag.Error = "Item is already added to your cart!";
                }

            }
            return totalAmount;
        }

        public bool checkOrderline(Orderline newOrderline)
        {
            var db = new DBContext();
            var existingMovieId = db.Orderlines.Where(a => a.MovieId == newOrderline.MovieId && a.OrderId == newOrderline.OrderId).SingleOrDefault();
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



            var orderId = (from order in db.Orders where order.SessionId == this.Session.SessionID && order.Confirmed == false select order.Id).SingleOrDefault();
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
            return View(movies);
        }

        public bool Delete(int id)
        {
            var db = new DBContext();
            Orderline orderline = db.Orderlines.First(x => x.MovieId == id);
            try
            {
                db.Orderlines.Remove(orderline);
                db.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        
        }

        public ActionResult Login()
        {
            if (Session["customer"] != null)
            {
                return RedirectToAction("Index", "Home", new { customer = Session["customer"].ToString() });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Customer Customer)
        {
            var db = new DBContext();
            var loggedIn = db.Customers.SingleOrDefault(c => c.Email == Customer.Email && c.Password == Customer.Password);

            if (loggedIn != null)
            {
                ViewBag.message = "You are logged in";
                ViewBag.triedOnce = true;

                Session["customer"] = Customer.Id;
                Order order = db.Orders.SingleOrDefault(x => x.Confirmed == false);
                order.Customer = Customer;
                return RedirectToAction("Index", "Home", new { customer = Customer.Id });
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home", new { customer = Session["customer"].ToString() });
            }

        }

        public string Confirmation()
        {
            if (Session["customer"] == null)
            {
                var message = "In order to procceed you need to log in!";
                return message;
            }
            else
            {
                var ok = "You will receive confirmation email with receipt!";
                changeConfirmationStatus();
                return ok;
            }
            


        } 
        

        public void changeConfirmationStatus()
        {
            if (Session["customer"] != null)
            {
                var db = new DBContext();
                Order order = db.Orders.Single(x => x.Confirmed == false);
                order.Confirmed = true;
                db.SaveChanges();
            }
        }

 
    }
}