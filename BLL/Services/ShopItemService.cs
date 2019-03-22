using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ShopItemService : IShopItemService
    {
        IUnitOfWorkPattern unitOfWork { get; set; }
        public ShopItemService(IUnitOfWorkPattern context)
        {
            unitOfWork = context;
        }

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

        public void Edit(DTOShopItem model)
        {
            var editModel = new ShopItem { Name = model.Name, Description = model.Description, Price = model.Price, PhotoPath = model.PhotoPath };
            unitOfWork.ShopItemRepository.Edit(editModel);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
