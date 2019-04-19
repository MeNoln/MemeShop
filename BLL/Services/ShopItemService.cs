using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

/// <summary>
/// Shop items service with using Automapper
/// </summary>
namespace BLL.Services
{
    //Shop item service class to work with
    public class ShopItemService : IShopItemService
    {
        //Pattern initialise
        IUnitOfWorkPattern unitOfWork { get; set; }
        public ShopItemService(IUnitOfWorkPattern context)
        {
            unitOfWork = context;
        }

        //Using AutoMapper to map DTO object with DAL
        public IEnumerable<DTOShopItem> GetAll()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<ShopItem, DTOShopItem>()).CreateMapper();
            return mapper.Map<IEnumerable<ShopItem>, List<DTOShopItem>>(unitOfWork.ShopItemRepository.GetAll());
        }

        public DTOShopItem Get(int? id)
        {
            if (id == null)
                throw new ErrorMessage("Not found", "");
            var item = unitOfWork.ShopItemRepository.Get(id.Value);
            if (item == null)
                throw new ErrorMessage("Item not found", "");
            return new DTOShopItem { Name = item.Name, Description = item.Description, Price = item.Price, PhotoPath = item.PhotoPath };
        }

        public void Create(DTOShopItem model)
        {
            var shopItem = new ShopItem { Name = model.Name, Description = model.Description, Price = model.Price, PhotoPath = model.PhotoPath};
            unitOfWork.ShopItemRepository.Create(shopItem);
        }

        public void Delete(int id)
        {
            unitOfWork.ShopItemRepository.Delete(id);
        }

        public void Edit(DTOShopItem context)
        {
            ShopItem model = new ShopItem {Id = context.Id, Name = context.Name, Description = context.Description, Price = context.Price, PhotoPath = context.PhotoPath };
            unitOfWork.ShopItemRepository.Edit(model);
        }

        //IDisposable pattern
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
