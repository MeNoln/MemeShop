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
    public class UoWAdminRepository : IUoWAdminPattern
    {
        private AdminContext db;
        private AdminRepository adminRepository;

        public UoWAdminRepository(string connect)
        {
            db = new AdminContext(connect);
        }
        
        public IAdminRepository<Admin> AdminRepository
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool dispose = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                    db.Dispose();
                this.dispose = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
