using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeShop.Controllers
{
    public class AdminPageController : Controller
    {
        IAdminSevice adminSevice { get; set; }
        public AdminPageController(IAdminSevice adminSevice)
        {
            this.adminSevice = adminSevice;
        }

        public ActionResult Validation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validation(AdminViewModel context)
        {
            DTOAdmin model = new DTOAdmin { Login = context.Login, Password = context.Password, PersonalKey = context.PersonalKey};
            bool flag = adminSevice.GetAdmin(model);

            if (flag)
                return RedirectToAction("AdminPanel", "AdminUI");
            return View(context);
        }
        
    }
}