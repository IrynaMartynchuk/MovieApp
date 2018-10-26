﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Controllers;
using MovieApp.BLL;
using MovieApp.DAL;
using MovieApp.Model;
using MvcContrib.TestHelper;

namespace UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void list()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var expected_result = new List<Admin>();

            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };

            expected_result.Add(admin);
            expected_result.Add(admin);
            expected_result.Add(admin);

            //Act
            var result = (ViewResult)controller.ListAdmins();
            var result_to_list = (List<Admin>)result.Model;

            //Assert
            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].AdminID, result_to_list[i].AdminID);
                Assert.AreEqual(expected_result[i].Adminuser, result_to_list[i].Adminuser);
                Assert.AreEqual(expected_result[i].PasswordAdmin, result_to_list[i].PasswordAdmin);
            }

        }

        [TestMethod]
        public void details_found()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var expected_result = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };
            //Act
            var actionResult = (ViewResult)controller.Details(1);
            var result = (Admin)actionResult.Model;

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expected_result.AdminID, result.AdminID);
            Assert.AreEqual(expected_result.Adminuser, result.Adminuser);
            Assert.AreEqual(expected_result.PasswordAdmin, result.PasswordAdmin);
        }

        [TestMethod]
        public void details_notfound()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.Details(0);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.EditAdmin(1);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit_false()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };

            //Act
            var actionResult = (ViewResult)controller.EditAdmin(0, admin);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit_true()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };
            //Act
            var actionResultat = (RedirectToRouteResult)controller.EditAdmin(1, admin);

            //Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "ListAdmins");
        }

        [TestMethod]
        public void add()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.RegisterAdmin();

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void add_true()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));

            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };
            //Act
            var result = (RedirectToRouteResult)controller.RegisterAdmin(admin);

            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "ListAdmins");
        }
        [TestMethod]
        public void add_no_input()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var admin = new Admin();
            controller.ViewData.ModelState.AddModelError("Username", "Username was not filled in");
            //Act
            var actionResult = (ViewResult)controller.RegisterAdmin(admin);
            //Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void add_false()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var admin = new Admin();
            admin.Adminuser = "";
            //Act
            var actionResult = (ViewResult)controller.RegisterAdmin(admin);
            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void login_view()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            //Act
            var actionResult = (ViewResult)controller.AdminIndex();
            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

    }
}
