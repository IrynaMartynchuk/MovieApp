using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class HomeBLL
    {
        
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

        public Customer login(Customer Customer)
        {
            var CustomerDAL = new CustomerDAL();
            var loggedIn = CustomerDAL.login(Customer);
            return loggedIn;
        }


    }
}
