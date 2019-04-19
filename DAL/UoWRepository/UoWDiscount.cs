using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces.IDiscountRepo;
using DAL.Interfaces.UoWPattern;
using DAL.Repositories;
using System;

/// <summary>
/// Unit of Work pattern with IDisposable pattern
/// </summary>
namespace DAL.UoWRepository
{
    public class UoWDiscount : IUoWDIscount
    {
        //Connection to database
        private DiscountContext db;
        private DiscountRepository discountRepository;
        public UoWDiscount(string connect)
        {
            db = new DiscountContext(connect);
        }

        //Initialising repository
        public IDiscountRepo<DiscountCode> DiscountRepository
        {
            get
            {
                if (discountRepository == null)
                    discountRepository = new DiscountRepository(db);
                return discountRepository;
            }
        }

        //Save changes in database method
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
