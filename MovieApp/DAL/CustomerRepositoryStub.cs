using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public class CustomerRepositoryStub : DAL.ICustomerRepository
    {
        public List<Customer> listCustomers()
        {
            var list_customers = new List<Customer>();
            var newCustomer = new Customer()
            {
                Id = 1,
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd",
            };
            list_customers.Add(newCustomer);
            list_customers.Add(newCustomer);

            return list_customers;
        }

        public bool addCustomer(Customer inCustomer)
        {
            if (inCustomer.Name == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Customer viewDetails(int id)
        {
            if (id == 0)
            {
                var customer = new Customer();
                customer.Id = 0;
                return customer;
            }
            else
            {
                var customer = new Customer()
                {
                    Id = 1,
                    Name = "Maja",
                    Surname = "Kiszka",
                    Email = "kiszka.maja@gmail.com",
                    Password = "12345678cd",
                };
                return customer;
            }
        }
        
            public bool deleteCustomer(int id)
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

        public bool editCustomer(int id, Customer customer)
        {
            if(id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}

