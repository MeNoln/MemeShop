using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces.IDiscountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This class inherits Repository Interface and represents all Data Access Logic
/// Actually all methods here are simple CRUD (Create, Delete, Get All)
/// </summary>
namespace DAL.Repositories
{
    public class DiscountRepository : IDiscountRepo<DiscountCode>
    {
        //Connection to database
        private DiscountContext db;
        public DiscountRepository(DiscountContext db)
        {
            this.db = db;
        }

        //New discount code creating
        public void Create(DiscountCode context)
        {
            db.DiscountCodes.Add(context);
            db.SaveChanges();
        }

        //Delete code from server
        public void Delete(int id)
        {
            var model = db.DiscountCodes.Find(id);
            db.DiscountCodes.Remove(model);
            db.SaveChanges();
        }

        //Get all discount code's
        public IEnumerable<DiscountCode> GetAllCodes()
        {
            return db.DiscountCodes;
        }
    }
}
