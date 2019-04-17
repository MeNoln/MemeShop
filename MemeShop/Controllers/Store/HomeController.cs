using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeShop.Controllers
{
    public class HomeController : Controller
    {
        IShopItemService shopItemService { get; set; }
        public HomeController(IShopItemService shopItemService)
        {
            this.shopItemService = shopItemService;
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult StoreMain()
        {
            StoreClassHelper helper = new StoreClassHelper(shopItemService);

            return View(helper.MapDTOWithViewModel());
        }
        
        public ActionResult Current(int id)
        {
            StoreClassHelper helper = new StoreClassHelper(shopItemService);
            
            return View(helper.ConvertFromDTOToViewModel(id));
        }

        protected override void Dispose(bool disposing)
        {
            shopItemService.Dispose();
            base.Dispose(disposing);
        }
    }
}