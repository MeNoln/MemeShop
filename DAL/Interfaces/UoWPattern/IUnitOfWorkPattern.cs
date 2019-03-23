﻿using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWorkPattern : IDisposable
    {
        IRepository<ShopItem> ShopItemRepository { get; }
        void Save();
    }
}
