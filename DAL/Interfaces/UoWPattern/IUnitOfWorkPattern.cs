using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    //Unit of Work pattern for Shop item's repo
    public interface IUnitOfWorkPattern : IDisposable
    {
        IRepository<ShopItem> ShopItemRepository { get; }
        void Save();
    }
}
