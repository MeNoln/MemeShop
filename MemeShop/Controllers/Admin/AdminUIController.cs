using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models;
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
            ShopItemViewModel model = new ShopItemViewModel { Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = context.PhotoPath };

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            var model = itemService.Get(id);
            string path = model.PhotoPath;
            string serverPath = Request.MapPath(path);

            if (System.IO.File.Exists(serverPath))
                System.IO.File.Delete(serverPath);

            itemService.Delete(id);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoPath")]ShopItemViewModel context)
        {
            DTOShopItem model = new DTOShopItem {Id = context.Id, Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = context.PhotoPath };
            itemService.Edit(model);

            return RedirectToAction("AdminPanel");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ShopItemViewModel context, HttpPostedFileBase image)
        {
            string modelPath = string.Empty;
            if (image.ContentLength > 0)
            {
                string filename = Path.GetFileName(image.FileName);
                string serverImgSave = Path.Combine(Server.MapPath("~/Images"), filename);
                image.SaveAs(serverImgSave);

                modelPath = "~/Images/" + filename;
            }

            DTOShopItem model = new DTOShopItem { Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = modelPath };
            itemService.Create(model);

            return RedirectToAction("AdminPanel");
        }
    }
}