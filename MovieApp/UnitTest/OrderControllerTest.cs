using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Controllers;
using MovieApp.BLL;
using MovieApp.DAL;
using MovieApp.Model;

namespace UnitTest
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void list()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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

            //Act
            var result = (ViewResult)controller.ListOrders();
            var result_to_list = (List<Order>)result.Model;

            //Assert
            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].Id, result_to_list[i].Id);
                Assert.AreEqual(expected_result[i].Confirmed, result_to_list[i].Confirmed);
                Assert.AreEqual(expected_result[i].SessionId, result_to_list[i].SessionId);
                Assert.AreEqual(expected_result[i].Customer, result_to_list[i].Customer);
            }

        }

        [TestMethod]
        public void delete()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.DeleteOrder(1);
            var result = (Order)actionResult.Model;

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void delete_found()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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

            //Act
            var actionResult = (RedirectToRouteResult)controller.DeleteOrder(1, order);

            //Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "ListOrders");
        }

        [TestMethod]
        public void delete_notfound()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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

            //Act
            var actionResult = (ViewResult)controller.DeleteOrder(0, order);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void details_found()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
            var expected_result = new Order()
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
            //Act
            var actionResult = (ViewResult)controller.ViewDetails(1);
            var result = (Order)actionResult.Model;

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expected_result.Id, result.Id);
            Assert.AreEqual(expected_result.Confirmed, result.Confirmed);
            Assert.AreEqual(expected_result.SessionId, result.SessionId);
            Assert.AreEqual(expected_result.Customer, result.Customer);
        }

        [TestMethod]
        public void details_notfound()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.ViewDetails(0);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.EditOrder(1);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit_false()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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

            //Act
            var actionResult = (ViewResult)controller.EditOrder(0, order);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit_true()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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
            //Act
            var actionResultat = (RedirectToRouteResult)controller.EditOrder(1, order);

            //Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "ListOrders");
        }

        [TestMethod]
        public void listOrderlines_found()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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

            //Act
            var result = (ViewResult)controller.getOrderlines(1);
            var result_to_list = (List<Orderline>)result.Model;

            //Assert
            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].Id, result_to_list[i].Id);
                Assert.AreEqual(expected_result[i].Antall, result_to_list[i].Antall);
                Assert.AreEqual(expected_result[i].MovieId, result_to_list[i].MovieId);
                Assert.AreEqual(expected_result[i].OrderId, result_to_list[i].OrderId);
                Assert.AreEqual(expected_result[i].Movie, result_to_list[i].Movie);
                Assert.AreEqual(expected_result[i].Order, result_to_list[i].Order);
            }

        }

        [TestMethod]
        public void listOrderlines_notfound()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.getOrderlines(0);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void listOrders_found()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));
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

            //Act
            var result = (ViewResult)controller.getOrders(1);
            var result_to_list = (List<Order>)result.Model;

            //Assert
            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].Id, result_to_list[i].Id);
                Assert.AreEqual(expected_result[i].Confirmed, result_to_list[i].Confirmed);
                Assert.AreEqual(expected_result[i].SessionId, result_to_list[i].SessionId);
                Assert.AreEqual(expected_result[i].Customer, result_to_list[i].Customer);
            }

        }

        [TestMethod]
        public void listOrders_notfound()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.getOrders(0);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

    }
}
