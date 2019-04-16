using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ShopItemRepository : IRepository<ShopItem>
    {
        private ShopItemContext db;
        public ShopItemRepository(ShopItemContext db)
        {
            this.db = db;
        }

        public void Create(ShopItem model)
        {
            db.ShopItems.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.ShopItems.Find(id);
            db.ShopItems.Remove(model);
            db.SaveChanges();
        }

        public void Edit(ShopItem model)
        {
            var obj = db.ShopItems.Find(model.Id);
            obj.Name = model.Name;
            obj.Description = model.Description;
            obj.Price = model.Price;
            obj.PhotoPath = model.PhotoPath;

            db.SaveChanges();
        }

        public ShopItem Get(int id)
        {
            return db.ShopItems.Find(id);
        }

        public IEnumerable<ShopItem> GetAll()
        {
            return db.ShopItems;
        }
    }
}
