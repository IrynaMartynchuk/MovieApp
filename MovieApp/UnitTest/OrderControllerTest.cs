using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
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

    }
}
