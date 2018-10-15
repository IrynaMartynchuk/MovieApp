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
        public bool saveCustomer(Customer inCustomer)
        {
            var CustomerDAL = new CustomerDAL();
            bool insertOK = CustomerDAL.saveCustomer(inCustomer);
            return insertOK;
        }
        
    }
}
