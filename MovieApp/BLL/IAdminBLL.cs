using System.Collections.Generic;
using MovieApp.Model;
using MovieApp.DAL;

namespace MovieApp.BLL
{
    public interface IAdminBLL
    {
        bool addAdmin(Admin admin);
        bool editAdmin(int id, dbAdmins admin);
        List<dbAdmins> listAdmins();
        dbAdmins login(Admin Admin);
        dbAdmins viewDetails(int id);
        bool deleteAdmin(int id);
    }
}