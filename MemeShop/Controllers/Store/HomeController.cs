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
            IEnumerable<DTOShopItem> shopItem = shopItemService.GetAll();
            var mapper = new MapperConfiguration(config => config.CreateMap<DTOShopItem, ShopItemViewModel>()).CreateMapper();
            var item = mapper.Map<IEnumerable<DTOShopItem>, List<ShopItemViewModel>>(shopItem);

            return View(item);
        }
        
        public ActionResult Current(int id)
        {
            var context = shopItemService.Get(id);
            ShopItemViewModel model = new ShopItemViewModel { Id = context.Id, Name = context.Name, Description = context.Description,
            Price = context.Price, PhotoPath = context.PhotoPath };
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            shopItemService.Dispose();
            base.Dispose(disposing);
        }
    }
}