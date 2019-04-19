using BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    //Admin service Interface
    public interface IAdminSevice
    {
        bool GetAdmin(DTOAdmin model);
    }
}
