using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using MovieApp.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace MovieApp.DAL
{
    public class CustomerDAL
    {

        public bool saveCustomer(Customer innKunde)
        {
            using (var db = new DBContext())
            {
                var existingCustomer = db.Customers.Where(a => a.Email == innKunde.Email).SingleOrDefault();
                if (existingCustomer == null)
                {
                    try
                    {
                        var newCustomer = new Customer();
                        newCustomer.Name = innKunde.Name;
                        newCustomer.Surname = innKunde.Surname;
                        newCustomer.Email = innKunde.Email;
                        newCustomer.Password = innKunde.Password;

                        db.Customers.Add(newCustomer);
                        db.SaveChanges();

                        return true;
                    }
                    catch (Exception feil)
                    {
                        return false;
                    }
                }
                else
                    return false;

            }
        } 

        /*public bool saveCustomer(Customer inCustomer)
        {
            var newCustomer = new Customer()
            {
                Name = inCustomer.Name,
                Surname = inCustomer.Surname,
                Email = inCustomer.Email
            };
            
            using (var db = new DBContext())
            {
                try
                {
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        } */
 
        public List<Customer> listCustomers()
        {
            using (var db = new DBContext()) 
            {
               /* List<Customer> allCustomers = db.Customers.Select(c => new Customer()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Email = c.Email
                }).ToList(); */
                List<Customer> allCustomers = (from customer in db.Customers.AsEnumerable()
                                               select new Customer()
                                               {
                                                   Id = customer.Id,
                                                   Name = customer.Name,
                                                   Surname = customer.Surname,
                                                   Email = customer.Email
                                               }).ToList();
                return allCustomers;
            }
        }

        public Customer viewDetails(int id) {
            using (var db = new DBContext())
            {
                var customer = db.Customers.Find(id);

                if (customer == null)
                {
                    return null;
                }
                else
                {
                    var orders = (from order in db.Orders where order.Customer.Id == id select order).ToList();
                    var details = new Customer()
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Surname = customer.Surname,
                        Email = customer.Email
                    };
                    return details;
                }
            }
        }

        public bool deleteCustomer(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Customer customer = db.Customers.Find(id);
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /*public bool editCustomer(int id, Customer inCustomer)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Customer changedCustomer = db.Customers.Find(id);
                    changedCustomer.Name = inCustomer.Name;
                    changedCustomer.Surname = inCustomer.Surname;
                    changedCustomer.Email = inCustomer.Email;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        } */

        public bool editCustomer(int id, Customer customer)
        {
            var db = new DBContext();
            var result = db.Customers.Find(id);

            if (result != null)
            {
                result.Name = customer.Name;
                result.Surname = customer.Surname;
                result.Email = customer.Email;
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



        /* public bool editCustomer(Customer cust)
        {
            var db = new StoreEntities();

            var result = db.Customers.Find(getCustomerId(cust.Email));
            if (result != null)
            {
                result.Firstname = cust.Firstname;
                result.Lastname = cust.Lastname;
                result.Address = cust.Address;
                result.ZipNumber = cust.ZipNumber;
                result.ZipPlace = cust.ZipPlace;
                result.Country = cust.Country;
                result.Phonenumber = cust.Phonenumber;
                try
                {
                    db.SaveChanges(user);
                    return true;
                }
                catch (Exception e)
                {
                    var sw = new System.IO.StreamWriter(filename, true);
                    sw.WriteLine(DateTime.Now.ToString() + " " + e.Message + e.StackTrace);
                    sw.Close();
                    return false;
                }
            }
            return false;
        }

        public bool editCustomer(int id, Customer inCustomer)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Customer customer = db.Customers.Find(id);
                    customer.Name = inCustomer.Name;
                    customer.Surname = inCustomer.Surname;
                    customer.Email = inCustomer.Email;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool endreKunde(int id, Kunde innKunde)
        {
            using (var db = new KundeContext())
            {


                try
                {
                    Kunder endreKunde = db.Kunder.Find(id);
                    endreKunde.Fornavn = innKunde.fornavn;
                    endreKunde.Etternavn = innKunde.etternavn;
                    endreKunde.Adresse = innKunde.adresse;
                  
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        } */

        public Customer login(Customer Customer)
        {
            using(var db = new DBContext())
            {
                var loggedIn = db.Customers.SingleOrDefault(c => c.Email == Customer.Email && c.Password == Customer.Password);
                var orders = db.Orders.SingleOrDefault(o => o.Confirmed == false);
                loggedIn.Orders.Add(orders);
                db.SaveChanges();
                return loggedIn;
            }
        }



        /*
        public bool checkCustomer(Customer inCustomer)
        {
            using (var db = new DBContext())
                var checkID = db.Customers.Find(inCustomer.Id);
            if (checkID == null) {
                //Pop-Up message (?)
            }
        } */
    }
}