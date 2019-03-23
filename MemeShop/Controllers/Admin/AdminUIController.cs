using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeShop.Controllers.Admin
{
    public class AdminUIController : Controller
    {
        IShopItemService itemService { get; set; }
        public AdminUIController(IShopItemService itemService)
        {
            this.itemService = itemService;
        }

        public ActionResult AdminPanel()
        {
            IEnumerable<DTOShopItem> shop = itemService.GetAll();
            var mapper = new MapperConfiguration(config => config.CreateMap<DTOShopItem, ShopItemViewModel>()).CreateMapper();
            var map = mapper.Map<IEnumerable<DTOShopItem>, List<ShopItemViewModel>>(shop);

            return View(map);
        }

        public ActionResult DeleteItem(int? id)
        {
            var context = itemService.Get(id);
            ShopItemViewModel model = new ShopItemViewModel { Name = context.Name, Description = context.Description, Price = context.Price};

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            itemService.Delete(id);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")]ShopItemViewModel context)
        {
            DTOShopItem model = new DTOShopItem {Id = context.Id, Name = context.Name, Description = context.Description, Price = context.Price };
            itemService.Edit(model);

            return RedirectToAction("AdminPanel");
        }
    }
}