using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Controllers
{
    public class AdminValidationHelper
    {
        IAdminSevice adminSevice { get; set; }
        public AdminValidationHelper(IAdminSevice adminSevice)
        {
            this.adminSevice = adminSevice;
        }

        public bool ValidAdmin(AdminViewModel context)
        {
            return checkAdminInDB(context);
        }
        
        private bool checkAdminInDB(AdminViewModel context)
        {
            DTOAdmin model = new DTOAdmin { Login = context.Login, Password = context.Password, PersonalKey = context.PersonalKey };
            return adminSevice.GetAdmin(model);
        }

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