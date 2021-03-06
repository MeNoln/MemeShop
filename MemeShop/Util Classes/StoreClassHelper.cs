﻿using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models;
using MemeShop.Models.EmailModel;
using System.Collections.Generic;
using System.Web.Helpers;

namespace MemeShop.Controllers
{
    //Utility class to make Controllers look better
    //And keep all logic here
    public class StoreClassHelper
    {
        IShopItemService shopItemService { get; set; }
        public StoreClassHelper(IShopItemService shopItemService)
        {
            this.shopItemService = shopItemService;
        }

        //Map Data Transfer Object with View Model object
        public List<ShopItemViewModel> MapDTOWithViewModel()
        {
            return mapDTOWithVM();
        }

        private List<ShopItemViewModel> mapDTOWithVM()
        {
            IEnumerable<DTOShopItem> shopItems = shopItemService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTOShopItem, ShopItemViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<DTOShopItem>, List<ShopItemViewModel>>(shopItems);
        }

        //Set class properties from View Model class to Data Transfer Object class
        public ShopItemViewModel ConvertFromDTOToViewModel(int id)
        {
            return convertDTOtoVM(id);
        }

        private ShopItemViewModel convertDTOtoVM(int id)
        {
            var context = shopItemService.Get(id);
            ShopItemViewModel model = new ShopItemViewModel {
                Id = context.Id,
                Name = context.Name,
                Description = context.Description,
                Price = context.Price,
                PhotoPath = context.PhotoPath
            };
            
            return model;
        }

        //SMTP port and sender settings. I'm using Google Mail account
        public void SetWebMailSMTP()
        {
            setWebMailSMTP();
        }

        private void setWebMailSMTP()
        {
            //Settings
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.EnableSsl = true;

            //From whom i`ll send message
            WebMail.UserName = "newgenerator05@gmail.com";
            WebMail.Password = "Qwerty1980";

            WebMail.From = "mark22dom@gmail.com";
        }

        //Generate and send Message to user
        public void SendMessageToUser(EmailSenderViewModel model)
        {
            sendMessageToUser(model);
        }

        private void sendMessageToUser(EmailSenderViewModel model)
        {
            //Settings for reciever, and message content
            WebMail.Send(to: model.Email,
                    subject: "Hello " + model.FirstName + "!",
                    isBodyHtml: true,
                    body: "<h3>We have just recieved your order</h3>" +
                    "<p>Checkout information about You:</p>" +
                    "<p><b>Your Name</b>: " + model.FirstName +
                    ", <b>Address</b>: " + model.Address +
                    ", <b>City</b>: " + model.City + "</p>" +
                    "<br />" + "<p><b>Your Postal Code</b>" + model.PostalCode + "</p>" +
                    "<br />" +
                    "<p>If the information correct, please wait for our company request!</p>" +
                    "<h4>Thank`s for buying!</h4>"
                    );
        }
    }
}