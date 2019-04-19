using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Controllers
{
    //Utility class to make Controllers look better
    //And keep all logic here
    public class AdminValidationHelper
    {
        IAdminSevice adminSevice { get; set; }
        public AdminValidationHelper(IAdminSevice adminSevice)
        {
            this.adminSevice = adminSevice;
        }

        //Method to find Admin in List
        public bool ValidAdmin(AdminViewModel context)
        {
            return checkAdminInDB(context);
        }
        
        private bool checkAdminInDB(AdminViewModel context)
        {
            DTOAdmin model = new DTOAdmin { Login = context.Login, Password = context.Password, PersonalKey = context.PersonalKey };
            return adminSevice.GetAdmin(model);
        }

        //Method to add Cookiez to user on 1 day
        public HttpCookie AddCookie()
        {
            return addcook();
        }

        private HttpCookie addcook()
        {
            HttpCookie cookie = new HttpCookie("authOk");
            cookie.Value = "authCookie";
            cookie.Expires = DateTime.Now.AddDays(1);
            return cookie;
        }
    }
}