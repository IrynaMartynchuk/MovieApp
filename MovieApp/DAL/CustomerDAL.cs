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

        public bool saveCustomer (Customer innKunde)
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
        }
        /*
          public bool lagreKunde(Kunde innKunde)
        {
            using (var db = new KundeContext())
            {
                try
                {
                    var nyKundeRad = new Kunder();
                    nyKundeRad.Fornavn = innKunde.fornavn;
                    nyKundeRad.Etternavn = innKunde.etternavn;
                    nyKundeRad.Adresse = innKunde.adresse;

                    var sjekkPostnr = db.Poststeder.Find(innKunde.postnr);
                    if (sjekkPostnr == null)
                    {
                        var poststedsRad = new Poststeder();
                        poststedsRad.Postnr = innKunde.postnr;
                        poststedsRad.Poststed = innKunde.poststed;
                        nyKundeRad.Poststeder = poststedsRad;
                    }
                    db.Kunder.Add(nyKundeRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }*/
    }
}