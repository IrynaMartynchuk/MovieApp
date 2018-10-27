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
            var expected_result = new List<dbAdmins>();

            var admin = new dbAdmins()
            {
                adminID = 1,
                adminUser = "Iryna",
                passwordAdmin = { }
            };

            expected_result.Add(admin);
            expected_result.Add(admin);
            expected_result.Add(admin);

            //Act
            var result = (ViewResult)controller.ListAdmins();
            var result_to_list = (List<dbAdmins>)result.Model;

            //Assert
            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].adminID, result_to_list[i].adminID);
                Assert.AreEqual(expected_result[i].adminUser, result_to_list[i].adminUser);
                Assert.AreEqual(expected_result[i].passwordAdmin, result_to_list[i].passwordAdmin );
            }

        }

        [TestMethod]
        public void details_found()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var expected_result = new dbAdmins()
            {
                adminID = 1,
                adminUser = "Iryna",
                passwordAdmin = { }
            };
            //Act
            var actionResult = (ViewResult)controller.Details(1);
            var result = (dbAdmins)actionResult.Model;

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expected_result.adminID, result.adminID);
            Assert.AreEqual(expected_result.adminUser, result.adminUser);
            Assert.AreEqual(expected_result.passwordAdmin, result.passwordAdmin);
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
            var admin = new dbAdmins()
            {
                adminID = 1,
                adminUser = "Iryna",
                passwordAdmin = { }
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
            var admin = new dbAdmins()
            {
                adminID = 1,
                adminUser = "Iryna",
                passwordAdmin = { }
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

        [TestMethod]
        public void login_true()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["admin"] = 1;
            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "ira",
                PasswordAdmin = "hello"
            };
            //Act
            var result = (RedirectToRouteResult)controller.AdminLogin(admin);

            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), 1);
        }

        [TestMethod]
        public void login_false()
        {
            //Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["admin"] = 1;
            controller.ViewData.ModelState.AddModelError("admin", "admin is null");
            var admin = new Admin()
            {
                AdminID = 0,
                Adminuser = "ira",
                PasswordAdmin = "hello"
            };
            //Act
            var result = (ViewResult)controller.AdminLogin(admin);

            //Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }







    }
}
