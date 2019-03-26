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

        public ActionResult Index()
        {
            IEnumerable<DTOShopItem> shopItem = shopItemService.GetAll();
            var mapper = new MapperConfiguration(config => config.CreateMap<DTOShopItem, ShopItemViewModel>()).CreateMapper();
            var item = mapper.Map<IEnumerable<DTOShopItem>, List<ShopItemViewModel>>(shopItem);

            return View(item);
        }
        

        protected override void Dispose(bool disposing)
        {
            shopItemService.Dispose();
            base.Dispose(disposing);
        }
    }
}