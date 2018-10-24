using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class CustomerBLL
    {
        public bool saveCustomer(Customer inCustomer)
        {
            var CustomerDAL = new CustomerDAL();
            bool insertOK = CustomerDAL.saveCustomer(inCustomer);
            return insertOK;
        }

        public bool addCustomer(Customer newCustomer)
        {
            var customerDAL = new CustomerDAL();
            bool insertOK = customerDAL.addCustomer(newCustomer);
            return insertOK;
        }

        public List<Customer> listCustomers()
        {
            var CustomerDAL = new CustomerDAL();
            List<Customer> allCustomers = CustomerDAL.listCustomers();
            return allCustomers;
        }

        public Customer viewDetails(int id)
        {
            var customerDAL = new CustomerDAL();
            return customerDAL.viewDetails(id);
        }

        public bool deleteCustomer(int id)
        {
            var customerDAL = new CustomerDAL();
            return customerDAL.deleteCustomer(id);
        }

        public bool editCustomer(int id, Customer inCustomer)
        {
            var customerDAL = new CustomerDAL();
            return customerDAL.editCustomer(id, inCustomer);
        }

        public void checkIfOldOrderExists(string sessionId)
        {
            var OrderDAL = new OrderDAL();
            OrderDAL.checkIfOldOrderExists(sessionId);
        }

        public void createOrder(string Id)
        {
            var OrderDAL = new OrderDAL();
            OrderDAL.createOrder(Id);
        }

        public List<Movie> retrieveAll()
        {
            var MovieDAL = new MovieDAL();
            List<Movie> allMovies = MovieDAL.retrieveAll();
            return allMovies;
        }

    }
}
