using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdminRepository : IAdminRepository<Admin>
    {
        List<Admin> list = Admin.Admins();
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
