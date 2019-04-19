using BLL.DataTransferObjects;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

/// <summary>
/// This serviceI need to get flag about admin's those we have on server
/// </summary>
namespace BLL.Services
{
    //Admin service class to work with
    public class AdminService : IAdminSevice
    {
        IUoWAdminPattern uowAdmin { get; set; }
        public AdminService(IUoWAdminPattern uowAdmin)
        {
            this.uowAdmin = uowAdmin;
        }

        //If we have this acount on server flag will be true, if not - false
        public bool GetAdmin(DTOAdmin context)
        {
            Admin model = new Admin { Login = context.Login, Password = context.Password, PersonalKey = context.PersonalKey };
            bool flag = uowAdmin.AdminRepository.GetAdmin(model);
            return flag;
        }
    }
}
