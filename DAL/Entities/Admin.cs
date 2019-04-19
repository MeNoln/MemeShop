using System.Collections.Generic;

namespace DAL.Entities
{
    //Admin class to access person to AdminUI
    public class Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PersonalKey { get; set; }

        //Admin list
        public static List<Admin> Admins()
        {
            List<Admin> list = new List<Admin>();
            list.Add(new Admin { Login = "admin", Password = "123", PersonalKey = "mark"});

            return list;
        }
    }
}
