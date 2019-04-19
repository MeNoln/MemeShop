using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UoWRepository
{
    public class UoWAdminRepository : IUoWAdminPattern
    {
        //No db connection because I use local admin check
        private AdminRepository adminRepository;
        
        //Initialising repository
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
