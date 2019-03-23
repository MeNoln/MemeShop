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
        private AdminRepository adminRepository;
        
        
        public IAdminRepository<Admin> AdminRepository
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository();
                return adminRepository;
            }
        }
    }
}
