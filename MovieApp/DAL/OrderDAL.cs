﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieApp.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MovieApp.DAL
{
    public class OrderDAL
    {
        public void checkIfOldOrderExists(string sessionId)
        {
            var db = new DBContext();
            Order oldOrder = db.Orders.SingleOrDefault(x => x.SessionId != sessionId && x.Confirmed == false);
            if (oldOrder != null)
            {
                db.Orders.Remove(oldOrder);
                db.SaveChanges();
            }
        }

        public void createOrder(string Id)
        {
            var db = new DBContext();
            var orderExist = db.Orders.SingleOrDefault(x => x.Confirmed == false);
            if (orderExist == null)
            {
                Order newOrder = new Order
                {
                    Date = DateTime.Now,
                    Confirmed = false,
                    SessionId = Id
                };
                db.Orders.Add(newOrder);
                db.SaveChanges();
            }
        }

        public void addOrderline(string id, int movieId)
        {
            var db = new DBContext();
            var newOrderline = new Orderline
            {
                Antall = 1,
                MovieId = movieId,
                OrderId = (from order in db.Orders where id == order.SessionId && order.Confirmed == false select order.Id).SingleOrDefault()
            };
            if (checkOrderline(newOrderline))
            {

                var orderlines = new List<Orderline>();
                orderlines.Add(newOrderline);
            }
            else
            {
              //  ViewBag.Error = "Item is already added to your cart!";
            }
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

        public List<Movie> showCartItems(string id)
        {
            var db = new DBContext();
            var orderId = (from order in db.Orders where order.SessionId == id && order.Confirmed == false select order.Id).SingleOrDefault();
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
            return movies;
        }

        public bool deleteCartItem (int id)
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

        public void changeConfirmedToTrue()
        {
            var db = new DBContext();
            Order order = db.Orders.Single(x => x.Confirmed == false);
            order.Confirmed = true;
            db.SaveChanges();
        }

        public List<Order> ListOrders()
        {
            using (var db = new DBContext())
            {
                List<Order> allOrders = (from order in db.Orders.AsEnumerable()
                                               select new Order()
                                               {
                                                   Date = order.Date,
                                                   Id = order.Id,
                                               }).ToList();
                return allOrders;
            }
        }

        public Order viewOrderDetails(int id)
        {
            using (var db = new DBContext())
            {
                var order = db.Orders.Find(id);

                if (order == null)
                {
                    return null;
                }
                else
                {
                    var details = new Order()
                    {
                        Id = order.Id,
                        Date = order.Date,
                    };
                    return details;
                }
            }
        }

        public bool DeleteOrder(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Order order = db.Orders.Find(id);
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool editOrder(int id, Order order)
        {
            var db = new DBContext();
            var result = db.Orders.Find(id);

            if (result != null)
            {
                result.Id = order.Id;
                result.Date = order.Date;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public List<Order> getOrders(int id)
        {
            var db = new DBContext();
            var orders = db.Orders.Where(o => o.Customer.Id == id).ToList();
 
            return orders;
        }

    }
}