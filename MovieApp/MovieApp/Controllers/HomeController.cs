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
            var DB = new DBContext();
            string sessionId = this.Session.SessionID;
           // Order oldOrder = DB.Orders.SingleOrDefault(x => x.SessionId != this.Session.SessionID && x.Confirmed == false);
            var db = new DBOrder();
            db.checkIfOldOrderExists(sessionId);
            
            //if(falseOrder != null)
            //{
            //    db.Orders.Remove(falseOrder);
            //    db.SaveChanges();

            //}
            
            
            if (Session["Cart"] == null || (bool)Session["Cart"] == false)
                {
                db.createOrder(sessionId);
                Session["Cart"] = true;
                //var orderExist = DB.Orders.Where(x => x.Confirmed == false || x.SessionId == this.Session.SessionID).SingleOrDefault();
                ////if (orderExist == null)
                // {
                // Order newOrder = new Order
                // {
                //    Date = DateTime.Now,
                //    Confirmed = false,
                //    SessionId = sessionId
                // };
                //  DB.Orders.Add(newOrder);
                //  DB.SaveChanges();
                //  Session["Cart"] = true;
                //  }

            }
            else
            {
                db.createOrder(sessionId);
               // var orderExist2 = DB.Orders.Where(x => x.Confirmed == false).SingleOrDefault();
               // if (orderExist2 == null)
               // {
               //     Order newOrder = new Order
               //     {
                //        Date = DateTime.Now,
                //        Confirmed = false,
                //        SessionId = sessionId
                //    };
                //    DB.Orders.Add(newOrder);
                //    DB.SaveChanges();
               // }
            }
            var Db = new DBMovie();
            List<Movie> allMovies = Db.retrieveAll();
            return View(allMovies);
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
            var orders = db.Orders.SingleOrDefault(o => o.Confirmed == false);
            loggedIn.Orders.Add(orders);
            db.SaveChanges();

            if (loggedIn != null)
            {
                ViewBag.message = "You are logged in";
                ViewBag.triedOnce = true;

                Session["customer"] = Customer.Id;
                return RedirectToAction("Index", "Home", new { customer = Customer.Id });
            }
            else
            {
                loggedIn.Orders.Add(orders);
                db.SaveChanges();
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

        
    }
}