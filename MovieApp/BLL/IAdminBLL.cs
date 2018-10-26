using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public interface IAdminBLL
    {
        bool addAdmin(Admin admin);
        bool editAdmin(int id, Admin admin);
        List<Admin> listAdmins();
        Admin login(Admin Admin);
        Admin viewDetails(int id);
    }
}