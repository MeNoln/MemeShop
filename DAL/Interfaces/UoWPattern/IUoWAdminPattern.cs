using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    //Unit of Work pattern for Admin repo
    public interface IUoWAdminPattern
    {
        IAdminRepository<Admin> AdminRepository { get; }
    }
}
