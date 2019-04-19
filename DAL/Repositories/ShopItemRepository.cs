using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

/// <summary>
/// This class inherits Repository Interface and represents all Data Access Logic
/// Actually all methods here are simple CRUD
/// </summary>
namespace DAL.Repositories
{
    public class ShopItemRepository : IRepository<ShopItem>
    {
        //Connection to database
        private ShopItemContext db;
        public ShopItemRepository(ShopItemContext db)
        {
            this.db = db;
        }

        //Add new item on server
        public void Create(ShopItem model)
        {
            db.ShopItems.Add(model);
            db.SaveChanges();
        }

        //Delete item from server
        public void Delete(int id)
        {
            var model = db.ShopItems.Find(id);
            db.ShopItems.Remove(model);
            db.SaveChanges();
        }

        //Change item properties
        public void Edit(ShopItem model)
        {
            var obj = db.ShopItems.Find(model.Id);
            obj.Name = model.Name;
            obj.Description = model.Description;
            obj.Price = model.Price;
            obj.PhotoPath = model.PhotoPath;

            db.SaveChanges();
        }

        //Get current item from database
        public ShopItem Get(int id)
        {
            return db.ShopItems.Find(id);
        }

        //Get all shop items from table
        public IEnumerable<ShopItem> GetAll()
        {
            return db.ShopItems;
        }
    }
}
