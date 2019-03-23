using DAL.EF6;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdminRepository : IAdminRepository<Admin>
    {
        private AdminContext db;
        public AdminRepository(AdminContext db)
        {
            this.db = db;
        }

        public Admin GetAdmin(int id)
        {
            return db.Admins.Find(id);
        }
    }
}
