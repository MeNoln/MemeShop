using BLL.DataTransferObjects;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
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

        public bool GetAdmin(DTOAdmin context)
        {
            Admin model = new Admin { Login = context.Login, Password = context.Password, PersonalKey = context.PersonalKey };
            bool flag = uowAdmin.AdminRepository.GetAdmin(model);
            return flag;
        }
    }
}
