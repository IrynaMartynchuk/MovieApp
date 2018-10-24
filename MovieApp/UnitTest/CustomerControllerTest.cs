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
        public void list()
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
    }
    
}
