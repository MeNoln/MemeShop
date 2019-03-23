using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PersonalKey { get; set; }

        public static List<Admin> Admins()
        {
            List<Admin> list = new List<Admin>();
            list.Add(new Admin { Login = "admin", Password = "123", PersonalKey = "mark"});

            return list;
        }
    }
}
