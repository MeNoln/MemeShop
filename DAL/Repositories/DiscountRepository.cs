using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces.IDiscountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountRepository : IDiscountRepo<DiscountCode>
    {
        private DiscountContext db;
        public DiscountRepository(DiscountContext db)
        {
            this.db = db;
        }

        public void Create(DiscountCode context)
        {
            db.DiscountCodes.Add(context);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.DiscountCodes.Find(id);
            db.DiscountCodes.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<DiscountCode> GetAllCodes()
        {
            return db.DiscountCodes;
        }
    }
}
