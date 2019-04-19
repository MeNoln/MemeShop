using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models;
using MemeShop.Models.DiscountCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeShop.Controllers.Admin
{
    public class AdminUIController : Controller
    {
        IShopItemService itemService { get; set; }
        IDiscountCodeService discountService { get; set; }
        public AdminUIController(IShopItemService itemService, IDiscountCodeService discountService)
        {
            this.itemService = itemService;
            this.discountService = discountService;
        }
        
        //Shop items UI

        public ActionResult AdminPanel()
        {
            if (!HttpContext.Request.Cookies.AllKeys.Contains("authOk"))
                return RedirectToAction("Validation", "AdminPage");

            AdminUIHelper helper = new AdminUIHelper(itemService);
            var map = helper.MapDTOWithViewModel();

            return View(map);
        }

        public ActionResult DeleteItem(int? id)
        {
             AdminUIHelper helper = new AdminUIHelper(itemService);
            
            return View(helper.GetCurrentUser(id));
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            AdminUIHelper helper = new AdminUIHelper(itemService);

            var model = itemService.Get(id);
            string shortPath = model.PhotoPath;
            string serverPath = Request.MapPath(helper.GetFullserverPath(id));
            helper.DeleteImageOnServer(serverPath, shortPath);
            helper.DeleteItemFromServer(id);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoPath")]ShopItemViewModel context, HttpPostedFileBase image)
        {
            AdminUIHelper helper = new AdminUIHelper(itemService);

            string modelPath = context.PhotoPath;
            if (image != null)
            {
                string serverImgPath = Path.Combine(Server.MapPath("~/Images"), helper.GetFullImageName(image));
                image.SaveAs(serverImgPath);
                
                string deletePath = Request.MapPath(helper.GetFullserverPath(context.Id));
                helper.DeleteImageOnServer(deletePath);

                modelPath = "~/Images/" + helper.GetFullImageName(image);
            }

            helper.EditItemOnServer(context, modelPath);
            
            return RedirectToAction("AdminPanel");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ShopItemViewModel context, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                AdminUIHelper helper = new AdminUIHelper(itemService);
                
                string serverImgPath = Path.Combine(Server.MapPath("~/Images"), helper.GetFullImageName(image));
                image.SaveAs(serverImgPath);

                string modelPath = "~/Images/" + helper.GetFullImageName(image);
                
                helper.CreateItemOnServer(context, modelPath);

                return RedirectToAction("AdminPanel");
            }

            return View();
        }

        //Discount codes UI

        public ActionResult Codes()
        {
            DiscountCodesHelper helper = new DiscountCodesHelper(discountService);

            return View(helper.MapDiscountVMWithDTO());
        }

        [HttpPost]
        public ActionResult CreateNewCode(DiscountMultupleViewModel context)
        {
            if (ModelState.IsValid)
            {
                DTODiscountCode model = new DTODiscountCode { Code = context.DiscountCodeVM.Code, DiscountPerCent = context.DiscountCodeVM.DiscountPerCent };
                discountService.Create(model);
            }
            
            return RedirectToAction("Codes");
        }
        
        public ActionResult DeleteDiscountCode(int id)
        {
            discountService.Delete(id);

            return RedirectToAction("Codes");
        }

        protected override void Dispose(bool disposing)
        {
            itemService.Dispose();
            base.Dispose(disposing);
        }
    }
}