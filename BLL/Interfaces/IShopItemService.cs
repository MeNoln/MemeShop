using BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IShopItemService
    {
        IEnumerable<DTOShopItem> GetAll();
        DTOShopItem Get(int? id);
        void Create(DTOShopItem model);
        void Delete(int id);
        void Edit(DTOShopItem model);
        void Dispose();
    }
}
