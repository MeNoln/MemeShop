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

        private List<ShopItemViewModel> createMap()
        {
            IEnumerable<DTOShopItem> shop = itemService.GetAll();
            var mapper = new MapperConfiguration(config => config.CreateMap<DTOShopItem, ShopItemViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<DTOShopItem>, List<ShopItemViewModel>>(shop);
        }

        public ShopItemViewModel GetCurrentUser(int? id)
        {
            return findInDB(id);
        }

        private ShopItemViewModel findInDB(int? id)
        {
            var context = itemService.Get(id);
            return new ShopItemViewModel { Name = context.Name, Description = context.Description,
                                           Price = context.Price, PhotoPath = context.PhotoPath };
        }

        public string GetFullserverPath(int id)
        {
            return getPath(id);
        }

        private string getPath(int id)
        {
            var model = itemService.Get(id);
            return model.PhotoPath;
        }

        public void DeleteImageOnServer(string serverpath)
        {
            deleteFromServer(serverpath);
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

        public void DeleteItemFromServer(int id)
        {
            deleteItem(id);
        }

        private void deleteItem(int id)
        {
            itemService.Delete(id);
        }

        public void EditItemOnServer(ShopItemViewModel context, string modelPath)
        {
            editItem(context, modelPath);
        }

        private void editItem(ShopItemViewModel context, string modelPath)
        {
            DTOShopItem model = new DTOShopItem { Id = context.Id, Name = context.Name,
                                                  Description = context.Description, Price = context.Price,
                                                  PhotoPath = modelPath };
            itemService.Edit(model);
        }

        public string GetFullImageName(HttpPostedFileBase image)
        {
            return getImageName(image);
        }

        private string getImageName(HttpPostedFileBase image)
        {
            string[] expansions = { ".tiff", ".jpeg", ".bmp", ".jpe", ".jpg", ".png", ".gif", ".psd", };
            try
            {
                string imgName = Path.GetFileName(image.FileName);
                foreach (var item in expansions)
                {
                    if (imgName.EndsWith(item))
                        return imgName;
                }
                throw new InvalidFileException("File not an image", "");
            }
            catch(NullReferenceException)
            {
                throw new EmptyFileException("File not found", "");
            }
        }

        public void CreateItemOnServer(ShopItemViewModel context, string modelPath)
        {
            createItem(context, modelPath);
        }
        
        private void createItem(ShopItemViewModel context, string modelPath)
        {
            try
            {
                DTOShopItem model = new DTOShopItem { Name = context.Name,
                                                      Description = context.Description,
                                                      Price = context.Price, PhotoPath = modelPath };
                itemService.Create(model);
            }
            catch (Exception)
            {
                throw new Exception("Failed to create item on server");
            }
            
        }
    }
}