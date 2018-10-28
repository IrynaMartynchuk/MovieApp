using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Model
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Name can contain only letters!")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Surname can contain only letters!")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$", ErrorMessage = "Wrong format of email!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-za-z\d]{8,}$", ErrorMessage = "Password must be minimum eight characters, at least one letter and one number!")]
        public string Password { get; set; }
        public virtual List<Order> Orders { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                Customer other = (Customer)obj;
                return Equals(other.Id, this.Id) && Equals(other.Name, this.Name) && Equals(other.Surname, this.Surname) &&
                    Equals(other.Email, this.Email) && Equals(other.Password, this.Password);
            }
            return false;
        }
            public override int GetHashCode()
        {
            return Id;
        }
    }
}