using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class AdminBLL
    {
        public Admin login(Admin Admin)
        {
            var AdminDAL = new AdminDAL();
            var loggedIn = AdminDAL.login(Admin);
            return loggedIn;
        }
    }
}
