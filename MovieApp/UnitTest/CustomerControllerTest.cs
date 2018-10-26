using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp.BLL;
using MovieApp.DAL;
using MovieApp.Controllers;
using MovieApp.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTest
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void list_all_customers()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var expected_result = new List<Customer>();
            var customer = new Customer()
            {
                Id = 1,
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd"
            };
            expected_result.Add(customer);
            expected_result.Add(customer);

            //Act

            var result = (ViewResult)controller.ListCustomers();
            var result_to_list = (List<Customer>)result.Model;

            //Assert

            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].Id, result_to_list[i].Id);
                Assert.AreEqual(expected_result[i].Name, result_to_list[i].Name);
                Assert.AreEqual(expected_result[i].Surname, result_to_list[i].Surname);
                Assert.AreEqual(expected_result[i].Password, result_to_list[i].Password);
            }
        }

        [TestMethod]
        public void register_show_view()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            //Act
            var result = (ViewResult)controller.RegisterCustomer();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void registration_ok_post()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer()
            {
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd"
            };
            //Act
            var result = (RedirectToRouteResult)controller.RegisterCustomer(in_customer);
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "ListCustomers");
        }

        [TestMethod]
        public void registration_incorrect_validation_post()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer();
            controller.ViewData.ModelState.AddModelError("Name", "Name not provided!");

            //Act
            var result = (ViewResult)controller.RegisterCustomer(in_customer);

            //Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]

        public void registration_incorrect_post()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer();
            in_customer.Name = "";

            //Act
            var result = (ViewResult)controller.RegisterCustomer(in_customer);

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void view_details_successful()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var expected_result = new Customer()
            {
                Id = 1,
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd",
            };
            //Act
            var result = (ViewResult)controller.ViewDetails(1);
            var res = (Customer)result.Model;

            //Assert
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(expected_result.Id, res.Id);
            Assert.AreEqual(expected_result.Name, res.Name);
            Assert.AreEqual(expected_result.Surname, res.Surname);
            Assert.AreEqual(expected_result.Email, res.Email);
            Assert.AreEqual(expected_result.Password, res.Password);
        }

        [TestMethod]
        public void delete()
        {
            // Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));

            // Act
            var action = (ViewResult)controller.DeleteCustomer(1);
            var resultat = (Customer)action.Model;

            // Assert
            Assert.AreEqual(action.ViewName, "");
        }

        [TestMethod]
        public void delete_successful()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer()
            {
                Id = 1,
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd"
            };

            //Act
            var result = (RedirectToRouteResult)controller.DeleteCustomer(1, in_customer);

            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "ListCustomers");

        }

        [TestMethod]
        public void delete_unsuccessful()
        {
            //Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer()
            {
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd"
            };

            //Act
            var result = (ViewResult)controller.DeleteCustomer(0, in_customer);

            //Assert
            Assert.AreEqual(result.ViewName, "");

        }

        [TestMethod]
        public void change_view_test()
        {
            // Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EditCustomer(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void change_found()
        {
            // Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer()
            {
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd"
            };
            // Act
            var result = (RedirectToRouteResult)controller.EditCustomer(1, in_customer);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "ListCustomers");
        }

        [TestMethod]
        public void change_not_found_view()
        {
            // Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));

            // Act
            var result = (ViewResult)controller.EditCustomer(0);
            var res = (Customer)result.Model;

            // Assert
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(res.Id, 0);
        }

        [TestMethod]
        public void change_not_found_post()
        {
            // Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer()
            {
                Id = 0,
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd"
            };

            // Act
            var result = (ViewResult)controller.EditCustomer(1, in_customer);

            // Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void change_unsuccessful_validation_post()
        {
            // Arrange
            var controller = new CustomerController(new CustomerBLL(new CustomerRepositoryStub()));
            var in_customer = new Customer();
            controller.ViewData.ModelState.AddModelError("mistake", "ID = 0");

            // Act
            var result = (ViewResult)controller.EditCustomer(1, in_customer);

            // Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewData.ModelState["mistake"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(result.ViewName, "");
        }
    }
    
}
