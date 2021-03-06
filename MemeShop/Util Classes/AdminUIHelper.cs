﻿using AutoMapper;
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
    //Utility class to make Controllers look better
    //And keep all logic here
    public class AdminUIHelper
    {
        IShopItemService itemService { get; set; }
        public AdminUIHelper(IShopItemService itemService)
        {
            this.itemService = itemService;
        }

        //Map Data Transfer Object to View Model object
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

        //Find Current product in Database
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

        //Generate full Image path
        public string GetFullserverPath(int id)
        {
            return getPath(id);
        }

        private string getPath(int id)
        {
            var model = itemService.Get(id);
            return model.PhotoPath;
        }

        //Delete Image from folder
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

        public void DeleteImageOnServer(string serverpath, string shortPath)
        {
            deleteFromServer(serverpath, shortPath);
        }

        private void deleteFromServer(string serverpath, string shortPath)
        {
            var allProducts = itemService.GetAll();
            var existOnServer = allProducts.Where(c => c.PhotoPath == shortPath);

            if (existOnServer == null)
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
        }

        //Delete object from Database
        public void DeleteItemFromServer(int id)
        {
            deleteItem(id);
        }

        private void deleteItem(int id)
        {
            itemService.Delete(id);
        }

        //Change item properties in Database
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

        //Get Image name. Example : ~/Images/test.img
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

        //Add new item in Database
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