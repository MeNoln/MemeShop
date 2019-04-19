using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Actually this is only Validatrion Controller
/// Also i use Helper class AdminValidationHelper to incapsulate all logic
/// </summary>
namespace MemeShop.Controllers
{
    //Admin Validation Controller
    public class AdminPageController : Controller
    {
        IAdminSevice adminSevice { get; set; }
        public AdminPageController(IAdminSevice adminSevice)
        {
            this.adminSevice = adminSevice;
        }

        //View with Login form
        public ActionResult Validation()
        {
            return View();
        }

        //If result OK adding Cookiez and accepting on AdminUI Page
        [HttpPost]
        public ActionResult Validation(AdminViewModel context)
        {
            //Class helper
            AdminValidationHelper helper = new AdminValidationHelper(adminSevice);
            bool flag = helper.ValidAdmin(context);

            if (flag)
            {
                HttpContext.Response.Cookies.Add(helper.AddCookie());
                return RedirectToAction("AdminPanel", "AdminUI");
            }

            return View(context);
        }
        
    }
}