using BLL.DataTransferObjects;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService : IAdminSevice
    {
        IUoWAdminPattern uowAdmin { get; set; }
        public AdminService(IUoWAdminPattern uowAdmin)
        {
            this.uowAdmin = uowAdmin;
        }

        public DTOAdmin GetAdmin(int id)
        {
            var model = uowAdmin.AdminRepository.GetAdmin(id);
            if(model == null)
                throw new ErrorMessage("Admin not found", "");
            return new DTOAdmin { Login = model.Login, Password = model.Password, PersonalKey = model.PersonalKey};
        }

        public void Dispose()
        {
            uowAdmin.Dispose();
        }
    }
}
