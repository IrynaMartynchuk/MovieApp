using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public class OrderRepositoryStub : DAL.IOrderRepository
    {
        public bool DeleteOrder(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool editOrder(int id, Order order)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Orderline> getOrderlines(int id)
        {
            if (id == 0)
            {
                return null;
            }
            else
            {
                var expected_result = new List<Orderline>();

                var orderline = new Orderline()
                {
                    Id = 1,
                    Antall = 1,
                    MovieId = 1,
                    OrderId = 1,
                    Movie = new Movie()
                    {
                        Id = 1,
                        ImageAddress = "/Images/avengers.jpg",
                        Title = "Avengers",
                        Description = "Lalala",
                        Price = 50,
                        Genre = "action"
                    },
                    Order = new Order()
                    {
                        Id = 1,
                        Confirmed = true,
                        SessionId = "hgfvjegvfjegvf",
                        Customer = new Customer()
                        {
                            Id = 1,
                            Name = "Iryna",
                            Surname = "Martynchuk",
                            Email = "martynchuk20101988@gmail.com",
                            Password = "5503371h"
                        }
                    }
                };

                expected_result.Add(orderline);
                expected_result.Add(orderline);
                expected_result.Add(orderline);
                return expected_result;
            }
        }

        public List<Order> getOrders(int id)
        {
            if(id == 0)
            {
                return null;
            }
            else
            {
                var expected_result = new List<Order>();

                var order = new Order()
                {
                    Id = 1,
                    Confirmed = true,
                    SessionId = "hgfvjegvfjegvf",
                    Customer = new Customer()
                    {
                        Id = 1,
                        Name = "Iryna",
                        Surname = "Martynchuk",
                        Email = "martynchuk20101988@gmail.com",
                        Password = "5503371h"
                    }
                };

                expected_result.Add(order);
                expected_result.Add(order);
                expected_result.Add(order);
                return expected_result;
            }
        }

        public List<Order> ListOrders()
        {
            var expected_result = new List<Order>();

            var order = new Order()
            {
                Id = 1,
                Confirmed = true,
                SessionId = "hgfvjegvfjegvf",
                Customer = new Customer()
                {
                    Id = 1,
                    Name = "Iryna",
                    Surname = "Martynchuk",
                    Email = "martynchuk20101988@gmail.com",
                    Password = "5503371h"
                }
            };

            expected_result.Add(order);
            expected_result.Add(order);
            expected_result.Add(order);
            return expected_result;
        }

        public Order viewOrderDetails(int id)
        {
            var order = new Order()
            {
                Id = 1,
                Confirmed = true,
                SessionId = "hgfvjegvfjegvf",
                Customer = new Customer()
                {
                    Id = 1,
                    Name = "Iryna",
                    Surname = "Martynchuk",
                    Email = "martynchuk20101988@gmail.com",
                    Password = "5503371h"
                }
            };
            if (id == 0)
            {
                return null;
            }
            else
            {
                var details = new Order()
                {
                    Id = order.Id,
                    Confirmed = order.Confirmed,
                    SessionId = order.SessionId,
                    Customer = order.Customer
                };
                return details;
            }
        }
    }
}
