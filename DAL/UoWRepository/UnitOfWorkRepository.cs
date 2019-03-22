using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoWRepository
{
    class UnitOfWorkRepository : IUnitOfWorkPattern
    {
        private ShopItemContext db;
        private ShopItemRepository shopItemRepo;
        public UnitOfWorkRepository(string connect)
        {
            db = new ShopItemContext(connect);
        }

        public IRepository<ShopItem> ShopItemRepository
        {
            get
            {
                if (shopItemRepo == null)
                    shopItemRepo = new ShopItemRepository(db);
                return shopItemRepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

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
