using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Model
{
    public class Admin
    {
        public int AdminID {get;set;}

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please provide the admin username")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Name can contain only letters!")] 
        public string Adminuser { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password should be filled in")]
        [DataType(DataType.Password)]
        public string PasswordAdmin { get; set; }
    }
}
 