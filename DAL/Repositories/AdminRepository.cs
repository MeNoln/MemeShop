using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// I need only one method in this Repository to accept flag about Admin
/// Idk how to create admin add/delete so i decided to create simple list that we can easily update from code
/// </summary>
namespace DAL.Repositories
{
    //Admin repo 
    public class AdminRepository : IAdminRepository<Admin>
    {
        List<Admin> list = Admin.Admins();

        //If data givven from user contains in Admin's list flag = true
        public bool GetAdmin(Admin model)
        {
            bool flag = false;
            foreach (var item in list)
            {
                if (item.Login == model.Login && item.Password == model.Password && item.PersonalKey == model.PersonalKey)
                    flag = true;
            }
            return flag;
        }
    }
}
