using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;

/// <summary>
/// Unit of Work pattern with IDisposable pattern
/// </summary>
namespace DAL.UoWRepository
{
    public class UnitOfWorkRepository : IUnitOfWorkPattern
    {
        //Connection to database
        private ShopItemContext db;
        private ShopItemRepository shopItemRepo;
        public UnitOfWorkRepository(string connect)
        {
            db = new ShopItemContext(connect);
        }

        //Initialising repository
        public IRepository<ShopItem> ShopItemRepository
        {
            get
            {
                if (shopItemRepo == null)
                    shopItemRepo = new ShopItemRepository(db);
                return shopItemRepo;
            }
        }

        //Method to save changes in database
        public void Save()
        {
            db.SaveChanges();
        }

        //IDisposable pattern
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
