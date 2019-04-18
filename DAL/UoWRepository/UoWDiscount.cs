using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces.IDiscountRepo;
using DAL.Interfaces.UoWPattern;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoWRepository
{
    public class UoWDiscount : IUoWDIscount
    {
        private DiscountContext db;
        private DiscountRepository discountRepository;
        public UoWDiscount(string connect)
        {
            db = new DiscountContext(connect);
        }

        public IDiscountRepo<DiscountCode> DiscountRepository
        {
            get
            {
                if (discountRepository == null)
                    discountRepository = new DiscountRepository(db);
                return discountRepository;
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
