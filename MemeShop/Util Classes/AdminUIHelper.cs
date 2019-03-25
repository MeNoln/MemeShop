using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.ExceptionFolder;
using MemeShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MemeShop.Controllers.Admin
{
    public class AdminUIHelper
    {
        IShopItemService itemService { get; set; }
        public AdminUIHelper(IShopItemService itemService)
        {
            this.itemService = itemService;
        }

        public List<ShopItemViewModel> MapDTOWithViewModel()
        {
            return createMap();
        }

        public ShopItemViewModel GetCurrentUser(int? id)
        {
            return findInDB(id);
        }

        public string GetFullserverPath(int id)
        {
            return getPath(id);
        }

        public void DeleteImageOnServer(string serverpath)
        {
            deleteFromServer(serverpath);
        }

        public void DeleteItemFromServer(int id)
        {
            deleteItem(id);
        }

        public void EditItemOnServer(ShopItemViewModel context)
        {
            editItem(context);
        }

        public string GetFullImageName(HttpPostedFileBase image)
        {
            return getImageName(image);
        }

        public void CreateItemOnServer(ShopItemViewModel context, string modelPath)
        {
            createItem(context, modelPath);
        }

        private List<ShopItemViewModel> createMap()
        {
            IEnumerable<DTOShopItem> shop = itemService.GetAll();
            var mapper = new MapperConfiguration(config => config.CreateMap<DTOShopItem, ShopItemViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<DTOShopItem>, List<ShopItemViewModel>>(shop);
        }

        private ShopItemViewModel findInDB(int? id)
        {
            var context = itemService.Get(id);
            return new ShopItemViewModel { Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = context.PhotoPath };
        }

        private string getPath(int id)
        {
            var model = itemService.Get(id);
            return model.PhotoPath;
        }

        private void deleteFromServer(string serverpath)
        {
            try
            {
                System.IO.File.Delete(serverpath);
            }
            catch (ImageNotOnServerException)
            {
                throw new ImageNotOnServerException("File not on server", "");
            }
        }

        private void deleteItem(int id)
        {
            itemService.Delete(id);
        }

        private void editItem(ShopItemViewModel context)
        {
            DTOShopItem model = new DTOShopItem { Id = context.Id, Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = context.PhotoPath };
            itemService.Edit(model);
        }

        private string getImageName(HttpPostedFileBase image)
        {
            try
            {
                return Path.GetFileName(image.FileName);
            }
            catch (EmptyFileException)
            {
                throw new EmptyFileException("File not found", "");
            }
        }

        private void createItem(ShopItemViewModel context, string modelPath)
        {
            try
            {
                DTOShopItem model = new DTOShopItem { Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = modelPath };
                itemService.Create(model);
            }
            catch (Exception)
            {
                throw new Exception("Failed to create item on server");
            }
            
        }
    }
}