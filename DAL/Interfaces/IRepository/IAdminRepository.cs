using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    //Admin Interface
    public interface IAdminRepository<T> where T : class
    {
        //Boolean because I use true/false like access flag
        bool GetAdmin(T model);
    }
}
