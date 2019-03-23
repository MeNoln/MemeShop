using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdminRepository<T> where T : class
    {
        T GetAdmin(int id);
    }
}
